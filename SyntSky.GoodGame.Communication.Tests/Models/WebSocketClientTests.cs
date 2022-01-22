using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using SyntSky.GoodGame.Communication.Clients;
using SyntSky.GoodGame.Communication.Events;
using WebSocketSharp;
using WebSocketSharp.Server;
using Xunit;

namespace SyntSky.GoodGame.Communication.Models;

public class WebSocketClientTests : IDisposable
{
	private readonly ClientOptions _clientOptions;
	private readonly Uri _clientOptionsUri;
	private readonly WebSocketServer _webSocketServer;

	public WebSocketClientTests()
	{
		var availablePort = GetAvailablePort();
		_webSocketServer = new WebSocketServer(availablePort);
		_clientOptions = new ClientOptions();

		_webSocketServer.AddWebSocketService<Echo>("/");

		_webSocketServer.Start();

		_clientOptionsUri = new UriBuilder("ws", "loopback", _webSocketServer.Port).Uri;
	}

	public void Dispose()
	{
		_webSocketServer.Stop();
	}

	[Fact]
	public void Client_Raises_OnConnected_EventArgs()
	{
		var client = new WebSocketClient(_clientOptions);
		var pauseConnected = new ManualResetEvent(false);

		var raisedEvent = Assert.Raises<OnConnectedArgs>(
			h => client.OnConnected += h,
			h => client.OnConnected -= h,
			() =>
			{
				client.OnConnected += (_, _) => pauseConnected.Set();
				client.Open(_clientOptionsUri);
				Assert.True(pauseConnected.WaitOne(TimeSpan.FromSeconds(5)));
			});
		Assert.NotNull(raisedEvent);
	}

	[Fact]
	public void Client_Raises_OnDisconnected_EventArgs()
	{
		var client = new WebSocketClient(_clientOptions);
		var pauseDisconnected = new ManualResetEvent(false);

		Assert.Raises<OnDisconnectedArgs>(
			h => client.OnDisconnected += h,
			h => client.OnDisconnected -= h,
			() =>
			{
				client.OnConnected += (_, _) => client.Close();
				client.OnDisconnected += (_, _) => pauseDisconnected.Set();
				client.Open(_clientOptionsUri);
				Assert.True(pauseDisconnected.WaitOne(TimeSpan.FromSeconds(20)));
			});
	}

	[Fact]
	public void Client_Raises_OnReconnected_EventArgs()
	{
		_clientOptions.IsAutoReconnect = true;
		var client = new WebSocketClient(_clientOptions);
		var pauseConnected = new ManualResetEvent(false);
		var pauseReconnected = new ManualResetEvent(false);


		var raisedEventOnConnected = Assert.Raises<OnConnectedArgs>(
			h => client.OnConnected += h,
			h => client.OnConnected -= h,
			() =>
			{
				client.OnConnected += (_, _) => pauseConnected.Set();
				client.Open(_clientOptionsUri);
				Assert.True(pauseConnected.WaitOne(TimeSpan.FromSeconds(5)));
			});

		Assert.NotNull(raisedEventOnConnected);

		var raisedEventOnReconnected = Assert.Raises<OnReconnectedArgs>(
			h => client.OnReconnected += h,
			h => client.OnReconnected -= h,
			() =>
			{
				client.OnReconnected += (_, _) => pauseReconnected.Set();
				client.Reconnect();
				Assert.True(pauseReconnected.WaitOne(TimeSpan.FromSeconds(20)));
			});


		Assert.NotNull(raisedEventOnReconnected);
	}

	[Fact]
	public void Client_Dispose_Before_Connecting_IsOK()
	{
		var client = new WebSocketClient(_clientOptions);
		client.Dispose();
	}

	[Fact]
	public void Client_SendAndReceive_Messages()
	{
		var client = new WebSocketClient(_clientOptions);
		var pauseConnected = new ManualResetEvent(false);
		var pauseReadMessage = new ManualResetEvent(false);


		var raisedEventOnConnected = Assert.Raises<OnConnectedArgs>(
			h => client.OnConnected += h,
			h => client.OnConnected -= h,
			() =>
			{
				client.OnConnected += (_, _) => pauseConnected.Set();
				client.Open(_clientOptionsUri);
				Assert.True(pauseConnected.WaitOne(TimeSpan.FromSeconds(5)));
			});

		Assert.NotNull(raisedEventOnConnected);

		var raisedEventOnMessage = Assert.Raises<OnMessageArgs>(
			h => client.OnMessage += h,
			h => client.OnMessage -= h,
			() =>
			{
				client.OnMessage += (_, _) => pauseReadMessage.Set();
				client.Send("ping");
				Assert.True(pauseReadMessage.WaitOne(TimeSpan.FromSeconds(5)));
			});


		Assert.NotNull(raisedEventOnMessage);
		Assert.Equal("pong", raisedEventOnMessage.Arguments.Message);
	}

	private static int GetAvailablePort()
	{
		var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
		var usedPorts = Enumerable.Empty<int>()
			.Concat(ipProperties.GetActiveTcpConnections().Select(c => c.LocalEndPoint.Port))
			.Concat(ipProperties.GetActiveTcpListeners().Select(l => l.Port))
			.Concat(ipProperties.GetActiveUdpListeners().Select(l => l.Port))
			.ToHashSet();
		for (var port = 1; port <= 65535; port++)
			if (!usedPorts.Contains(port))
				return port;

		return 0;
	}
}

public class Echo : WebSocketBehavior
{
	protected override void OnMessage(MessageEventArgs e)
	{
		switch (e.Data)
		{
			case "ping":
				Send("pong");
				break;
		}
	}
}