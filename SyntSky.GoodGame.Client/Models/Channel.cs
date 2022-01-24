namespace SyntSky.GoodGame.Client.Models;

public class Channel
{
	public Channel(long channelId, string channelName)
	{
		ChannelId = channelId;
		ChannelName = channelName;
	}

	public long ChannelId { get; init; }
	public string ChannelName { get; init; }

	public ChannelState ChannelState { get; } = new();
}