namespace SyntSky.GoodGame.Communication.Events;

public class OnStateChangedArgs : EventArgs
{
	public bool IsConnected { get; init; }
	public bool WasConnected { get; init; }
}