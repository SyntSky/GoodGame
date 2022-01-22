using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnMessageRemoveArgs : EventArgs
{
	public ResRemoveMessageDto Data;

	public OnMessageRemoveArgs(ResRemoveMessageDto data)
	{
		Data = data;
	}
}