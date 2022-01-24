namespace SyntSky.GoodGame.Communication.Events;

public class OnSendFailedArgs : EventArgs
{
	public OnSendFailedArgs(string data, Exception exception)
	{
		Data = data;
		Exception = exception;
	}

	public string Data { get; init; }
	public Exception Exception { get; init; }
}