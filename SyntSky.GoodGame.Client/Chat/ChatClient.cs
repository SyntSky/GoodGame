using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SyntSky.GoodGame.Client.Dto;
using SyntSky.GoodGame.Client.Dto.Chat;
using SyntSky.GoodGame.Client.Events;
using SyntSky.GoodGame.Client.Interfaces;
using SyntSky.GoodGame.Client.Models;
using SyntSky.GoodGame.Communication.Events;
using SyntSky.GoodGame.Communication.Interfaces;

namespace SyntSky.GoodGame.Client.Chat;

public partial class ChatClient : IChatClient
{
	private const int ApiVersion = 2;

	private readonly IClient _client;

	private readonly ConcurrentQueue<long> _joinChannelQueue = new();

	private readonly ConcurrentDictionary<long, Channel> _joinedChannels = new();
	private readonly ConcurrentQueue<long> _leavingChannelQueue = new();
	private readonly ILogger<ChatClient> _logger;

	private AccountCredentials _connectionCredentials = AccountCredentials.GuestCredentials();

	public ChatClient(IClient client, ILogger<ChatClient>? logger)
	{
		_client = client ?? throw new ArgumentNullException(nameof(client));
		_logger = logger ?? NullLogger<ChatClient>.Instance;

		InitializeClient();
	}

	public bool IsAuth { get; private set; }

	public bool IsGuest => IsAuth & (ConnectionCredentials.UserId == 0);
	public IReadOnlyDictionary<long, Channel> JoinedChannels => _joinedChannels;


	public event EventHandler<OnConnectedArgs>? OnConnected;
	public event EventHandler<OnErrorArgs>? OnConnectedError;
	public event EventHandler<OnFatalErrorArgs>? OnConnectedFatalError;
	public event EventHandler<OnDisconnectedArgs>? OnDisconnected;
	public event EventHandler<OnReconnectedArgs>? OnReconnected;
	public event EventHandler<OnDonateArgs>? OnDonate;
	public event EventHandler<OnMessageReceivedArgs>? OnMessageReceived;
	public event EventHandler<OnMessageRemoveArgs>? OnMessageRemove;
	public event EventHandler<OnMessageThrottledArgs>? OnMessageThrottled;
	public event EventHandler<OnJoinedChannelArgs>? OnJoinedChannel;
	public event EventHandler<OnLeaveChannelArgs>? OnLeaveChannel;
	public event EventHandler<OnRefreshViewersArgs>? OnRefreshViewers;
	public event EventHandler<OnUserBanArgs>? OnUserBan;
	public event EventHandler<OnUpdateChannelInfoArgs>? OnUpdateChannelInfo;
	public event EventHandler<OnFollowerArgs>? OnFollower;
	public event EventHandler<OnGiftedPremiumsArgs>? OnGiftedPremiums;
	public event EventHandler<OnPremiumArgs>? OnPremium;
	public event EventHandler<OnUserWarnArgs>? OnUserWarn;
	public event EventHandler<OnPrivateMessageArgs>? OnPrivateMessage;
	public event EventHandler<OnNewPollArgs>? OnNewPoll;
	public event EventHandler<OnUpdateJobArgs>? OnUpdateJob;
	public event EventHandler<OnChangeChatSettingArgs>? OnChangeChatSetting;
	public event EventHandler<OnLogInArgs>? OnLogInSuccess;
	public event EventHandler<OnLogInArgs>? OnLogInError;

	public AccountCredentials ConnectionCredentials
	{
		get => _connectionCredentials;
		set
		{
			if (Equals(value, _connectionCredentials)) return;
			_connectionCredentials = value;
			if (IsConnected) LoginIn();
		}
	}

	public bool IsConnected => _client.IsConnected;

	public bool Connect()
	{
		var uri = _client.Options.UseSsl
			? new Uri("wss://chat-1.goodgame.ru/chat2/")
			: new Uri("ws://chat-1.goodgame.ru/chat2/");

		_logger.LogInformation("Connecting to: {Uri}", uri);

		_joinedChannels.Clear();

		if (!_client.Open(uri)) return false;

		_logger.LogInformation("Should be connected!");
		return true;
	}

	public void Disconnect()
	{
		_client.Close();

		_joinedChannels.Clear();
	}

	public void JoinChannel(long channelId)
	{
		if (!IsConnected) return;
		if (_joinedChannels.ContainsKey(channelId)) return;

		_joinChannelQueue.Enqueue(channelId);
		if (_joinChannelQueue.Count == 1)
			QueueingJoinCheck();
	}


	public bool LeaveChannel(long channelId)
	{
		_joinedChannels.TryGetValue(channelId, out var joinedChannel);
		if (joinedChannel == null) return false;

		_leavingChannelQueue.Enqueue(channelId);
		if (_leavingChannelQueue.Count == 1)
			QueueingLeavingCheck();
		return true;
	}

	public bool SendMessageToAllChannel(string message)
	{
		return _joinedChannels.Aggregate(true,
			(current, joinedChannel) => current & SendMessage(joinedChannel.Key, message));
	}

	public bool SendMessage(long channelId, string message)
	{
		var channel = JoinedChannels[channelId];
		return ReqSendMessage(channel, message);
	}

	public bool CreateNewPoll(long channelId, string title, IEnumerable<string> answers)
	{
		var reqNewPollAnswers = answers.Select(answer => new ReqNewPollAnswer {Text = answer}).ToList();

		return ReqNewPoll(channelId, title, reqNewPollAnswers);
	}

	private void InitializeClient()
	{
		_client.OnConnected += ClientOnConnected;
		_client.OnMessage += ClientOnMessage;
		_client.OnDisconnected += clientOnDisconnected;
		_client.OnFatalityError += ClientOnFatalityError;
		_client.OnMessageThrottled += ClientOnMessageThrottled;
		_client.OnReconnected += ClientOnReconnected;
		_client.OnError += ClientOnError;
	}


	private void LoginIn()
	{
		ReqAuth(ConnectionCredentials.UserId, ConnectionCredentials.Token);
	}

	private void QueueingJoinCheck()
	{
		var isSuccess = _joinChannelQueue.TryDequeue(out var channelId);

		if (isSuccess)
		{
			_logger.LogInformation("Joining channelId: {ChannelId}", channelId);

			ReqJoinChannel(channelId!);
		}
		else
		{
			_logger.LogInformation("Finished channel joining queue");
		}
	}

	private void QueueingLeavingCheck()
	{
		var isSuccess = _leavingChannelQueue.TryPeek(out var channelId);
		if (isSuccess)
		{
			_logger.LogInformation("Leaving channelId: {ChannelId}", channelId);
			ReqUnJoinChannel(channelId!);
		}
		else
		{
			_logger.LogInformation("Finished channel Leave queue");
		}
	}

	private bool SendCommand(ChatRootDto chatWebsocketDto)
	{
		var serializeChatCommand = JsonSerializer.Serialize(chatWebsocketDto);
		return _client.Send(serializeChatCommand);
	}

	private void HandleServerMessage(ChatRootDto chatRootDto)
	{
		switch (chatRootDto.Data)
		{
			case ResMessageDto resMessageDto:
				ResMessage(resMessageDto);
				break;
			case ResNewPollDto resNewPollDto:
				ResNewPoll(resNewPollDto);
				break;
			case ResChannelCountersDto resChannelCountersDto:
				ResChannelCounters(resChannelCountersDto);
				break;
			case ResPaymentDto resPaymentDto:
				ResPayment(resPaymentDto);
				break;
			case ResPremiumDto resPremiumDto:
				ResPremium(resPremiumDto);
				break;
			case ResPrivateMessageDto resPrivateMessageDto:
				ResPrivateMessage(resPrivateMessageDto);
				break;
			case ResRemoveMessageDto resRemoveMessageDto:
				ResRemoveMessage(resRemoveMessageDto);
				break;
			case ResSettingDto resSettingDto:
				ResSetting(resSettingDto);
				break;
			case ResSuccessAuthDto resSuccessAuthDto:
				ResSuccessAuth(resSuccessAuthDto);
				break;
			case ResSuccessJoinDto resSuccessJoinDto:
				ResSuccessJoin(resSuccessJoinDto);
				break;
			case ResUnJoinDto unJoinDto:
				ResUnJoinChannel(unJoinDto);
				break;
			case ResUpdateChannelInfoDto resUpdateChannelInfoDto:
				ResUpdateChannelInfo(resUpdateChannelInfoDto);
				break;
			case ResUpdateJobDto resUpdateJobDto:
				ResUpdateJob(resUpdateJobDto);
				break;
			case ResUserBanDto resUserBanDto:
				ResUserBan(resUserBanDto);
				break;
			case ResFollowerDto resFollowerDto:
				ResFollower(resFollowerDto);
				break;
			case ResGiftedPremiumsDto resGiftedPremiumsDto:
				ResGiftedPremiums(resGiftedPremiumsDto);
				break;
			case ResUserWarnDto resUserWarnDto:
				ResUserWarn(resUserWarnDto);
				break;
			case ResWelcomeDto resWelcomeDto:
				ResWelcome(resWelcomeDto);
				break;
			case ResErrorDto resErrorDto:
				ResError(resErrorDto);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(chatRootDto.Data));
		}
	}

	#region ClientEventHandlers

	private void ClientOnConnected(object? sender, OnConnectedArgs e)
	{
		OnConnected?.Invoke(sender, e);

		LoginIn();

		if (!_joinChannelQueue.IsEmpty) QueueingJoinCheck();
	}

	private void ClientOnMessage(object? sender, OnMessageArgs args)
	{
		try
		{
			var generalViewJsonMessage = JsonSerializer.Deserialize<ChatRootDto>(args.Message);
			if (generalViewJsonMessage == null) return;

			HandleServerMessage(generalViewJsonMessage);
		}
		catch (JsonException e)
		{
			_logger.LogError(e, "Received an unknown message: {RawMessage}", args.Message);
		}
		catch (KeyNotFoundException e)
		{
			_logger.LogError(e, "Receive not implemented command: {RawMessage}", args.Message);
		}
	}

	private void clientOnDisconnected(object? sender, OnDisconnectedArgs e)
	{
		IsAuth = false;
		foreach (var joinedChannel in _joinedChannels) _joinChannelQueue.Enqueue(joinedChannel.Key);
		_joinedChannels.Clear();
		OnDisconnected?.Invoke(sender, e);
	}

	private void ClientOnFatalityError(object? sender, OnFatalErrorArgs e)
	{
		IsAuth = false;
		OnConnectedFatalError?.Invoke(sender, e);
	}

	private void ClientOnMessageThrottled(object? sender, OnMessageThrottledArgs e)
	{
		OnMessageThrottled?.Invoke(sender, e);
	}

	private void ClientOnReconnected(object? sender, OnReconnectedArgs e)
	{
		OnReconnected?.Invoke(sender, e);
		if (!_joinChannelQueue.IsEmpty) QueueingJoinCheck();
	}

	private void ClientOnError(object? sender, OnErrorArgs e)
	{
		OnConnectedError?.Invoke(sender, e);
	}

	#endregion
}