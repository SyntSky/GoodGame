using Microsoft.Extensions.Logging;
using SyntSky.GoodGame.Client.Dto.Chat;
using SyntSky.GoodGame.Client.Events;
using SyntSky.GoodGame.Client.Models;

namespace SyntSky.GoodGame.Client.Chat;

public partial class ChatClient
{
	private void ResWelcome(ResWelcomeDto resWelcomeDto)
	{
		if (resWelcomeDto.ProtocolVersion != ApiVersion)
			_logger.LogWarning(
				"The api version returned by the site is not as expected. SiteAPI:{resWelcomeDto.ProtocolVersion} Expected version: {ApiVersion}",
				resWelcomeDto.ProtocolVersion, ApiVersion);
	}

	private void ResSuccessAuth(ResSuccessAuthDto resSuccessAuthDto)
	{
		if (resSuccessAuthDto.UserId == ConnectionCredentials.UserId)
		{
			IsAuth = true;
			OnLogInSuccess?.Invoke(this, new OnLogInArgs(resSuccessAuthDto));
		}
		else
		{
			IsAuth = false;
			OnLogInError?.Invoke(this, new OnLogInArgs(resSuccessAuthDto));
		}
	}

	private void ResMessage(ResMessageDto resMessageDto)
	{
		OnMessageReceived?.Invoke(this, new OnMessageReceivedArgs(resMessageDto));
	}

	private void ResRemoveMessage(ResRemoveMessageDto resRemoveMessageDto)
	{
		OnMessageRemove?.Invoke(this, new OnMessageRemoveArgs(resRemoveMessageDto));
	}

	private void ResChannelCounters(ResChannelCountersDto resChannelCountersDto)
	{
		OnRefreshViewers?.Invoke(this, new OnRefreshViewersArgs(resChannelCountersDto));
	}

	private void ResSuccessJoin(ResSuccessJoinDto resSuccessJoinDto)
	{
		_joinedChannels.TryAdd(resSuccessJoinDto.ChannelId,
			new Channel(resSuccessJoinDto.ChannelId, resSuccessJoinDto.ChannelName));

		OnJoinedChannel?.Invoke(this, new OnJoinedChannelArgs(resSuccessJoinDto));

		OnRefreshViewers?.Invoke(this, new OnRefreshViewersArgs(new ResChannelCountersDto
		{
			ChannelId = resSuccessJoinDto.ChannelId,
			ClientsInChannel = resSuccessJoinDto.ClientsInChannel,
			UsersInChannel = resSuccessJoinDto.UsersInChannel
		}));

		QueueingJoinCheck();
	}

	private void ResUnJoinChannel(ResUnJoinDto resUnJoinDto)
	{
		var isSuccess = _leavingChannelQueue.TryDequeue(out var channelId);

		if (!isSuccess)
		{
			_logger.LogError("Leaving an unknown channel occurred");
		}
		else
		{
			if (resUnJoinDto.Success) _joinedChannels.TryRemove(channelId!, out _);

			OnLeaveChannel?.Invoke(this, new OnLeaveChannelArgs(channelId!, resUnJoinDto));
		}

		QueueingLeavingCheck();
	}

	private void ResPayment(ResPaymentDto resPaymentDto)
	{
		OnDonate?.Invoke(this, new OnDonateArgs(resPaymentDto));
	}

	private void ResPremium(ResPremiumDto resPremiumDto)
	{
		OnPremium?.Invoke(this, new OnPremiumArgs(resPremiumDto));
	}

	private void ResUserWarn(ResUserWarnDto resUserWarnDto)
	{
		OnUserWarn?.Invoke(this, new OnUserWarnArgs(resUserWarnDto));
	}

	private void ResError(ResErrorDto resErrorDto)
	{
		switch (resErrorDto.ErrorNum)
		{
			case >= 0 and <= 100:
			case >= 101 and <= 200:
			case >= 201 and <= 300:
				_logger.LogError("ChannelId:{ChannelId} Return error <{ErrorNum}> {ErrorMsg}", resErrorDto.ChannelId,
					resErrorDto.ErrorNum,
					resErrorDto.ErrorMsg);
				break;
			default:
				_logger.LogError("ChannelId:{ChannelId} Return unknown error <{ErrorNum}> {ErrorMsg}",
					resErrorDto.ChannelId,
					resErrorDto.ErrorNum,
					resErrorDto.ErrorMsg);
				break;
		}
	}

	private void ResPrivateMessage(ResPrivateMessageDto resPrivateMessageDto)
	{
		OnPrivateMessage?.Invoke(this, new OnPrivateMessageArgs(resPrivateMessageDto));
	}

	private void ResGiftedPremiums(ResGiftedPremiumsDto resGiftedPremiumsDto)
	{
		OnGiftedPremiums?.Invoke(this, new OnGiftedPremiumsArgs(resGiftedPremiumsDto));
	}

	private void ResFollower(ResFollowerDto resFollowerDto)
	{
		OnFollower?.Invoke(this, new OnFollowerArgs(resFollowerDto));
	}

	private void ResUserBan(ResUserBanDto resUserBanDto)
	{
		OnUserBan?.Invoke(this, new OnUserBanArgs(resUserBanDto));
	}

	private void ResUpdateChannelInfo(ResUpdateChannelInfoDto resUpdateChannelInfoDto)
	{
		OnUpdateChannelInfo?.Invoke(this, new OnUpdateChannelInfoArgs(resUpdateChannelInfoDto));
	}

	private void ResSetting(ResSettingDto resSettingDto)
	{
		OnChangeChatSetting?.Invoke(this, new OnChangeChatSettingArgs(resSettingDto));
	}

	private void ResNewPoll(ResNewPollDto resNewPollDto)
	{
		OnNewPoll?.Invoke(this, new OnNewPollArgs(resNewPollDto));
	}

	private void ResUpdateJob(ResUpdateJobDto resUpdateJobDto)
	{
		OnUpdateJob?.Invoke(this, new OnUpdateJobArgs(resUpdateJobDto));
	}
}