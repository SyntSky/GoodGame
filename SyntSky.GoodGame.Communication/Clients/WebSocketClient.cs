using System.Net.WebSockets;
using System.Text;
using SyntSky.GoodGame.Communication.Events;
using SyntSky.GoodGame.Communication.Interfaces;
using SyntSky.GoodGame.Communication.Models;
using SyntSky.GoodGame.Communication.Services;

namespace SyntSky.GoodGame.Communication.Clients;

public class WebSocketClient : IClient
{
	private readonly Throttlers _throttlers;
	private bool _isDisposed;
	private Task? _monitorTask;
	private bool _networkServicesRunning;
	private Task[]? _networkTasks;
	private bool _stopServices;
	private CancellationTokenSource _tokenSource = new();

	public WebSocketClient(IClientOptions? options = null)
	{
		Options = options ?? new ClientOptions();

		_throttlers = new Throttlers(this)
		{
			Token = _tokenSource.Token
		};
	}

	public ClientWebSocket? Client { get; private set; }
	public TimeSpan DefaultKeepAliveInterval { get; set; }
	public Uri? Url { get; private set; }
	public int SendQueueLength => _throttlers.SendQueue.Count;
	public bool IsConnected => Client?.State == WebSocketState.Open;
	public IClientOptions Options { get; init; }

	public event EventHandler<OnConnectedArgs>? OnConnected;
	public event EventHandler<OnDisconnectedArgs>? OnDisconnected;
	public event EventHandler<OnErrorArgs>? OnError;
	public event EventHandler<OnFatalErrorArgs>? OnFatalityError;
	public event EventHandler<OnMessageArgs>? OnMessage;
	public event EventHandler<OnMessageThrottledArgs>? OnMessageThrottled;
	public event EventHandler<OnSendFailedArgs>? OnSendFailed;
	public event EventHandler<OnStateChangedArgs>? OnStateChanged;
	public event EventHandler<OnReconnectedArgs>? OnReconnected;

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		Client?.Abort();
		_stopServices = true;
		CleanupServices();
		OnDisconnected?.Invoke(this, new OnDisconnectedArgs());
	}


	public bool Open(Uri uri)
	{
		try
		{
			if (Url != uri)
			{
				if (IsConnected) Close();
				Url = uri;
			}

			if (IsConnected) return true;

			InitializeClient();
			Client!.ConnectAsync(uri, _tokenSource.Token).Wait(10000);
			if (!IsConnected) return Open(uri);

			StartNetworkServices();
			return true;
		}
		catch (WebSocketException)
		{
			InitializeClient();
			return false;
		}
	}

	public bool Send(string message)
	{
		try
		{
			if (!IsConnected || SendQueueLength >= Options.SendQueueCapacity) return false;

			_throttlers.SendQueue.Add(new Tuple<DateTime, string>(DateTime.UtcNow, message));

			return true;
		}
		catch (Exception ex)
		{
			OnError?.Invoke(this, new OnErrorArgs(ex));
			return false;
		}
	}

	public void Reconnect()
	{
		Close();
		if (Url == null)
			return;
		if (Open(Url))
			OnReconnected?.Invoke(this, new OnReconnectedArgs());
	}

	public void MessageThrottled(OnMessageThrottledArgs args)
	{
		OnMessageThrottled?.Invoke(this, args);
	}

	public void SendFailed(OnSendFailedArgs args)
	{
		OnSendFailed?.Invoke(this, args);
	}

	public void Error(OnErrorArgs args)
	{
		OnError?.Invoke(this, args);
	}

	private void ReleaseUnmanagedResources()
	{
		Close();
		_throttlers.ShouldDispose = true;
		_tokenSource.Cancel();
		Thread.Sleep(1000);
	}

	private void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			ReleaseUnmanagedResources();
			if (disposing)
			{
				_tokenSource.Dispose();
				Client?.Dispose();
			}

			_isDisposed = true;
		}
	}

	~WebSocketClient()
	{
		Dispose(false);
	}

	private void CleanupServices()
	{
		_tokenSource.Cancel();
		_tokenSource = new CancellationTokenSource();
		_throttlers.Token = _tokenSource.Token;

		if (!_stopServices) return;
		if (!(_networkTasks?.Length > 0)) return;
		if (Task.WaitAll(_networkTasks, 15000)) return;

		OnFatalityError?.Invoke(this,
			new OnFatalErrorArgs("Fatal network error. Network services fail to shut down."));
		_stopServices = true;
		_throttlers.Reconnecting = false;
		_networkServicesRunning = false;
	}


	private void InitializeClient()
	{
		Client?.Abort();
		Client = new ClientWebSocket();

		if (_monitorTask == null)
		{
			_monitorTask = StartMonitorTask();
			return;
		}

		if (_monitorTask.IsCompleted) _monitorTask = StartMonitorTask();
	}


	private void StartNetworkServices()
	{
		_networkServicesRunning = true;
		_networkTasks = new[]
		{
			StartListenerTask(),
			_throttlers.StartSenderTask()
		}.ToArray();

		if (!_networkTasks.Any(c => c.IsFaulted)) return;
		_networkServicesRunning = false;
		CleanupServices();
	}

	private Task StartListenerTask()
	{
		return Task.Run(async () =>
		{
			var message = string.Empty;

			while (IsConnected && _networkServicesRunning)
			{
				WebSocketReceiveResult result;
				var buffer = new byte[Options.ReceiveMessageBufferSize];

				try
				{
					result = await Client!.ReceiveAsync(new ArraySegment<byte>(buffer), _tokenSource.Token);
				}
				catch
				{
					InitializeClient();
					break;
				}

				switch (result.MessageType)
				{
					case WebSocketMessageType.Close:
						Close();
						break;
					case WebSocketMessageType.Text when !result.EndOfMessage:
						message += Encoding.UTF8.GetString(buffer).TrimEnd('\0');
						continue;
					case WebSocketMessageType.Text:
						message += Encoding.UTF8.GetString(buffer).TrimEnd('\0');
						OnMessage?.Invoke(this, new OnMessageArgs(message));
						break;
					case WebSocketMessageType.Binary:
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				message = string.Empty;
			}
		});
	}

	private Task StartMonitorTask()
	{
		return Task.Run(() =>
		{
			var needsReconnect = false;
			try
			{
				var lastStateIsConnected = IsConnected;
				while (!_tokenSource.IsCancellationRequested)
				{
					if (lastStateIsConnected == IsConnected)
					{
						Thread.Sleep(200);
						continue;
					}

					OnStateChanged?.Invoke(this,
						new OnStateChangedArgs
							{IsConnected = Client!.State == WebSocketState.Open, WasConnected = lastStateIsConnected});

					if (IsConnected)
						OnConnected?.Invoke(this, new OnConnectedArgs());

					if (!IsConnected && !_stopServices)
					{
						if (lastStateIsConnected && Options.IsAutoReconnect)
						{
							needsReconnect = true;
							break;
						}

						OnDisconnected?.Invoke(this, new OnDisconnectedArgs());
						if (Client!.CloseStatus != null && Client.CloseStatus != WebSocketCloseStatus.NormalClosure)
							OnError?.Invoke(this,
								new OnErrorArgs(new Exception(Client.CloseStatus + " " +
								                              Client.CloseStatusDescription)));
					}

					lastStateIsConnected = IsConnected;
				}
			}
			catch (Exception ex)
			{
				OnError?.Invoke(this, new OnErrorArgs(ex));
			}

			if (needsReconnect && !_stopServices)
				Reconnect();
		}, _tokenSource.Token);
	}

	public Task SendAsync(byte[] message)
	{
		return Client!.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text, true, _tokenSource.Token);
	}
}