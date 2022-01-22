using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnUserBanArgs : EventArgs
{
	public OnUserBanArgs(ResUserBanDto data)
	{
		Data = data;
	}

	public ResUserBanDto Data { get; init; }
}