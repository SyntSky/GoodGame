using SyntSky.GoodGame.Client.Events;
using SyntSky.GoodGame.Client.Models;
using SyntSky.GoodGame.Communication.Events;

namespace SyntSky.GoodGame.Client.Interfaces;

public interface IChatClient
{
	public IReadOnlyDictionary<long, Channel> JoinedChannels { get; }
	public AccountCredentials ConnectionCredentials { get; set; }

	bool IsConnected { get; }

	public event EventHandler<OnConnectedArgs> OnConnected;
	public event EventHandler<OnErrorArgs> OnConnectedError;
	public event EventHandler<OnFatalErrorArgs> OnConnectedFatalError;
	public event EventHandler<OnDisconnectedArgs> OnDisconnected;
	public event EventHandler<OnReconnectedArgs> OnReconnected;
	public event EventHandler<OnDonateArgs> OnDonate;
	public event EventHandler<OnMessageReceivedArgs> OnMessageReceived;
	public event EventHandler<OnMessageRemoveArgs> OnMessageRemove;
	public event EventHandler<OnMessageThrottledArgs> OnMessageThrottled;
	public event EventHandler<OnJoinedChannelArgs> OnJoinedChannel;
	public event EventHandler<OnLeaveChannelArgs> OnLeaveChannel;
	public event EventHandler<OnRefreshViewersArgs> OnRefreshViewers;
	public event EventHandler<OnUserBanArgs> OnUserBan;
	public event EventHandler<OnUpdateChannelInfoArgs> OnUpdateChannelInfo;
	public event EventHandler<OnFollowerArgs> OnFollower;
	public event EventHandler<OnGiftedPremiumsArgs> OnGiftedPremiums;
	public event EventHandler<OnPremiumArgs> OnPremium;
	public event EventHandler<OnUserWarnArgs> OnUserWarn;
	public event EventHandler<OnPrivateMessageArgs> OnPrivateMessage;
	public event EventHandler<OnNewPollArgs> OnNewPoll;
	public event EventHandler<OnUpdateJobArgs> OnUpdateJob;
	public event EventHandler<OnChangeChatSettingArgs> OnChangeChatSetting;
	public event EventHandler<OnLogInArgs> OnLogInSuccess;
	public event EventHandler<OnLogInArgs> OnLogInError;


	bool Connect();

	void Disconnect();

	void JoinChannel(long channelId);
	bool LeaveChannel(long channelId);

	bool SendMessageToAllChannel(string message);
	bool SendMessage(long channelId, string message);
	bool CreateNewPoll(long channelId, string title, IEnumerable<string> answers);
}