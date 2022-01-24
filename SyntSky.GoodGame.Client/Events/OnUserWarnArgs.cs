using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnUserWarnArgs : EventArgs
{
	public OnUserWarnArgs(ResUserWarnDto userWarnDto)
	{
		UserWarnDto = userWarnDto;
	}

	public ResUserWarnDto UserWarnDto { get; init; }
}