using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnJoinedChannelArgs : EventArgs
{
	public OnJoinedChannelArgs(ResSuccessJoinDto successJoinDto)
	{
		SuccessJoinDto = successJoinDto;
	}

	public ResSuccessJoinDto SuccessJoinDto { get; init; }
}