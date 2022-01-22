namespace SyntSky.GoodGame.Communication.Events;

public class OnMessageArgs : EventArgs
{
	public OnMessageArgs(string message)
	{
		Message = message;
	}

	public string Message { get; init; }
}