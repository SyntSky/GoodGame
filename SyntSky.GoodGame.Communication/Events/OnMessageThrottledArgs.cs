namespace SyntSky.GoodGame.Communication.Events;

public class OnMessageThrottledArgs : EventArgs
{
	public OnMessageThrottledArgs(string message, int sentMessageCount, TimeSpan period, int allowedInPeriod)
	{
		Message = message;
		SentMessageCount = sentMessageCount;
		Period = period;
		AllowedInPeriod = allowedInPeriod;
	}

	public string Message { get; init; }

	public int SentMessageCount { get; init; }

	public TimeSpan Period { get; init; }

	public int AllowedInPeriod { get; init; }
}