using System.Collections.Concurrent;
using System.Text;
using SyntSky.GoodGame.Communication.Clients;
using SyntSky.GoodGame.Communication.Events;
using SyntSky.GoodGame.Communication.Interfaces;

namespace SyntSky.GoodGame.Communication.Services;

public class Throttlers
{
	private readonly IClient _client;

	private readonly TimeSpan _throttlingPeriod;

	public readonly BlockingCollection<Tuple<DateTime, string>> SendQueue = new();

	public Task? ResetThrottler;
	public bool ResetThrottlerRunning;
	public int SentCount;

	public Throttlers(IClient client)
	{
		_client = client;
		_throttlingPeriod = _client.Options.ThrottlingPeriod;
	}


	public bool Reconnecting { get; set; } = false;
	public bool ShouldDispose { get; set; } = false;
	public CancellationToken Token { get; set; }

	public void StartThrottlingWindowReset()
	{
		ResetThrottler = Task.Run(async () =>
		{
			ResetThrottlerRunning = true;
			while (!Token.IsCancellationRequested && !Reconnecting)
			{
				Interlocked.Exchange(ref SentCount, 0);
				await Task.Delay(_throttlingPeriod, Token);
			}

			ResetThrottlerRunning = false;
			return Task.CompletedTask;
		}, Token);
	}

	public void IncrementSentCount()
	{
		Interlocked.Increment(ref SentCount);
	}

	public Task StartSenderTask()
	{
		StartThrottlingWindowReset();

		return Task.Run(async () =>
		{
			try
			{
				while (!Token.IsCancellationRequested)
				{
					await Task.Delay(_client.Options.SendDelay, Token);

					if (SentCount == _client.Options.MessagesAllowedInPeriod)
					{
						_client.MessageThrottled(new OnMessageThrottledArgs(
							"Too Many Messages within the period specified in ClientOptions.",
							_client.Options.MessagesAllowedInPeriod,
							_client.Options.ThrottlingPeriod,
							Interlocked.CompareExchange(ref SentCount, 0, 0))
						);

						continue;
					}

					if (!_client.IsConnected || ShouldDispose) continue;

					var (addDateTime, message) = SendQueue.Take(Token);
					if (addDateTime.Add(_client.Options.SendCacheItemTimeout) < DateTime.UtcNow) continue;

					try
					{
						switch (_client)
						{
							case WebSocketClient ws:
								await ws.SendAsync(Encoding.UTF8.GetBytes(message));
								break;
						}

						IncrementSentCount();
					}
					catch (Exception ex)
					{
						_client.SendFailed(new OnSendFailedArgs(message, ex));
						break;
					}
				}
			}
			catch (OperationCanceledException ex)
			{
				if (SendQueue.Count != 0) _client.SendFailed(new OnSendFailedArgs("", ex));
			}
			catch (Exception ex)
			{
				_client.SendFailed(new OnSendFailedArgs("", ex));
				_client.Error(new OnErrorArgs(ex));
			}
		}, Token);
	}
}