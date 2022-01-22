using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnFollowerArgs : EventArgs
{
	public OnFollowerArgs(ResFollowerDto data)
	{
		Data = data;
	}

	public ResFollowerDto Data { get; init; }
}