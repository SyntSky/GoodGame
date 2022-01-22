namespace SyntSky.GoodGame.Communication.Events;

public class OnFatalErrorArgs : EventArgs
{
	public OnFatalErrorArgs(string reason)
	{
		Reason = reason;
	}

	public string Reason { get; init; }
}