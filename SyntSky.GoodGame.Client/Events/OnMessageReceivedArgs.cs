using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnMessageReceivedArgs : EventArgs
{
	public OnMessageReceivedArgs(ResMessageDto messageDto)
	{
		MessageDto = messageDto;
	}

	public ResMessageDto MessageDto { get; init; }
}