using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnLogInArgs : EventArgs
{
	public OnLogInArgs(ResSuccessAuthDto successAuthDto)
	{
		SuccessAuthDto = successAuthDto;
	}

	public ResSuccessAuthDto SuccessAuthDto { get; init; }
}