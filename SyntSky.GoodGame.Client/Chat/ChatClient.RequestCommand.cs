using EnumsNET;
using SyntSky.GoodGame.Client.Dto;
using SyntSky.GoodGame.Client.Dto.Chat;
using SyntSky.GoodGame.Client.Models;

namespace SyntSky.GoodGame.Client.Chat;

public partial class ChatClient
{
	private bool ReqJoinChannel(long channelId, bool hidden = false)
	{
		return SendCommand(new ChatRootDto("join", new ReqJoinDto
		{
			ChannelId = channelId,
			Hidden = hidden
		}));
	}

	private bool ReqUnJoinChannel(long channelId)
	{
		return SendCommand(new ChatRootDto("unjoin", new ReqUnJoinDto
		{
			ChannelId = channelId
		}));
	}

	private bool ReqAuth(long userId, string token)
	{
		return SendCommand(new ChatRootDto("auth", new ReqAuthDto
		{
			UserId = userId,
			Token = token
		}));
	}

	private bool ReqSendMessage(Channel channel, string text)
	{
		return SendCommand(new ChatRootDto("send_message", new ReqSendMessageDto
		{
			ChannelId = channel.ChannelId,
			Color = channel.ChannelState.Color.AsString(EnumFormat.Description) ??
			        throw new InvalidCastException($"ChatColor:{channel.ChannelState.Color} don't have description"),
			Icon = channel.ChannelState.Icon.AsString(EnumFormat.Description) ??
			       throw new InvalidCastException($"ChatIcon:{channel.ChannelState.Icon} don't have description"),
			Mobile = 0,
			Role = "",
			Text = text
		}));
	}

	private bool ReqNewPoll(long channelId, string title, List<ReqNewPollAnswer> answers)
	{
		return SendCommand(new ChatRootDto("new_poll", new ReqNewPoll
		{
			Answers = answers,
			Voters = 0,
			Title = title,
			ChannelId = channelId
		}));
	}
}