using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnChangeChatSettingArgs : EventArgs
{
	public OnChangeChatSettingArgs(ResSettingDto data)
	{
		Data = data;
	}

	public ResSettingDto Data { get; init; }
}