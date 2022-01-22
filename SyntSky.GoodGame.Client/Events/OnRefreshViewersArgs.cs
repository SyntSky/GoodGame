using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnRefreshViewersArgs : EventArgs
{
	public OnRefreshViewersArgs(ResChannelCountersDto channelCountersDto)
	{
		ChannelCountersDto = channelCountersDto;
	}

	public ResChannelCountersDto ChannelCountersDto { get; init; }
}