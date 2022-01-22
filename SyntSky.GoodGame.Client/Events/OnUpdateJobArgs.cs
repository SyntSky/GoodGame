using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnUpdateJobArgs : EventArgs
{
	public OnUpdateJobArgs(ResUpdateJobDto data)
	{
		Data = data;
	}

	public ResUpdateJobDto Data { get; init; }
}