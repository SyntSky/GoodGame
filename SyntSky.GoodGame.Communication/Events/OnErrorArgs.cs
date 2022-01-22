namespace SyntSky.GoodGame.Communication.Events;

public class OnErrorArgs : EventArgs
{
	public OnErrorArgs(Exception exception)
	{
		Exception = exception;
	}

	public Exception Exception { get; init; }
}