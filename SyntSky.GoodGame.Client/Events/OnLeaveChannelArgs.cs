using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnLeaveChannelArgs : EventArgs
{
	public OnLeaveChannelArgs(long channelId, ResUnJoinDto unJoinDto)
	{
		ChannelId = channelId;
		UnJoinDto = unJoinDto;
	}

	public long ChannelId { get; init; }
	public ResUnJoinDto UnJoinDto { get; init; }
}