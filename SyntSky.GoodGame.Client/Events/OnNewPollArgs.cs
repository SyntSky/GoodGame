using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnNewPollArgs : EventArgs
{
	public OnNewPollArgs(ResNewPollDto data)
	{
		Data = data;
	}

	public ResNewPollDto Data { get; init; }
}