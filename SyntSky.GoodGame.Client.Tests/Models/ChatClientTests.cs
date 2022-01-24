using System;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using SyntSky.GoodGame.Client.Chat;
using SyntSky.GoodGame.Communication.Events;
using SyntSky.GoodGame.Communication.Interfaces;
using Xunit;

namespace SyntSky.GoodGame.Client.Models;

public class ChatClientTests
{
	private readonly ChatClient _chatClient;
	private readonly Mock<IClient> _mockConnectClient;

	public ChatClientTests()
	{
		_mockConnectClient = new Mock<IClient>();
		_mockConnectClient.Setup(client => client.Open(It.IsAny<Uri>())).Returns(false);
		_mockConnectClient.Setup(client => client.Open(new Uri("wss://chat-1.goodgame.ru/chat2/")))
			.Returns(true)
			.Raises(e => e.OnConnected += null, new OnConnectedArgs());
		_mockConnectClient.Setup(client => client.Open(new Uri("ws://chat-1.goodgame.ru/chat2/")))
			.Returns(true)
			.Raises(e => e.OnConnected += null, new OnConnectedArgs());
		_mockConnectClient.Setup(client => client.Options.UseSsl).Returns(true);

		_chatClient = new ChatClient(_mockConnectClient.Object, new NullLogger<ChatClient>());
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void ChatClient_Connect_IsOk(bool useSsl)
	{
		_mockConnectClient.Setup(client => client.Open(new Uri("wss://chat-1.goodgame.ru/chat2/"))).Returns(useSsl);
		_mockConnectClient.Setup(client => client.Open(new Uri("ws://chat-1.goodgame.ru/chat2/")))
			.Returns(!useSsl);
		_mockConnectClient.Setup(client => client.Options.UseSsl).Returns(useSsl);

		var isConnect = _chatClient.Connect();

		Assert.True(isConnect);
	}


	// [Fact]
	// public void ChatClient_Raises_OnConnected_EventArgs()
	// {
	// 	var pauseConnected = new ManualResetEvent(false);
	//
	// 	var raisedEvent = Assert.Raises<OnConnectedEventArgs>(
	// 		h => _mockConnectClient.Object.OnConnected += h,
	// 		h => _mockConnectClient.Object.OnConnected -= h,
	// 		() =>
	// 		{
	// 			_mockConnectClient.Object.OnConnected += (sender, e) => pauseConnected.Set();
	// 			_chatClient.Connect();
	// 			Assert.True(pauseConnected.WaitOne(TimeSpan.FromSeconds(5)));
	// 		});
	// 	Assert.NotNull(raisedEvent);
	// }
}