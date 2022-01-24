using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnPrivateMessageArgs : EventArgs
{
	public OnPrivateMessageArgs(ResPrivateMessageDto data)
	{
		Data = data;
	}

	public ResPrivateMessageDto Data { get; init; }
}