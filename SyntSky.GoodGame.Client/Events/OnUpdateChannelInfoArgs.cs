using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnUpdateChannelInfoArgs : EventArgs
{
	public OnUpdateChannelInfoArgs(ResUpdateChannelInfoDto data)
	{
		Data = data;
	}

	public ResUpdateChannelInfoDto Data { get; init; }
}