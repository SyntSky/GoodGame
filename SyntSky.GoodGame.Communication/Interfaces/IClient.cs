using SyntSky.GoodGame.Communication.Events;

namespace SyntSky.GoodGame.Communication.Interfaces;

public interface IClient : IDisposable
{
	public Uri? Url { get; }

	/// <summary>
	///     The number of items waiting to be sent.
	/// </summary>
	int SendQueueLength { get; }

	/// <summary>
	///     The current state of the connection.
	/// </summary>
	bool IsConnected { get; }

	/// <summary>
	///     Client config
	/// </summary>
	IClientOptions Options { get; }

	/// <summary>
	///     Triggers when the Client is connected
	/// </summary>
	event EventHandler<OnConnectedArgs> OnConnected;

	/// <summary>
	///     Triggers when the Client disconnects
	/// </summary>
	event EventHandler<OnDisconnectedArgs> OnDisconnected;

	/// <summary>
	///     Triggers when An Exception occurs in the client
	/// </summary>
	event EventHandler<OnErrorArgs> OnError;

	/// <summary>
	///     Triggers when a Fatal error occurs.
	/// </summary>
	event EventHandler<OnFatalErrorArgs> OnFatalityError;

	/// <summary>
	///     Triggers when a Message (group of Messages) is received.
	/// </summary>
	event EventHandler<OnMessageArgs> OnMessage;

	/// <summary>
	///     Triggers when a Message has been throttled.
	/// </summary>
	event EventHandler<OnMessageThrottledArgs> OnMessageThrottled;

	/// <summary>
	///     Triggers when a message Send event failed.
	/// </summary>
	event EventHandler<OnSendFailedArgs> OnSendFailed;

	/// <summary>
	///     Triggers when the connection state changes
	/// </summary>
	event EventHandler<OnStateChangedArgs> OnStateChanged;

	/// <summary>
	///     Triggers when the client reconnects
	/// </summary>
	event EventHandler<OnReconnectedArgs> OnReconnected;

	/// <summary>
	///     Disconnect the Client from the Server
	/// </summary>
	void Close();

	/// <summary>
	///     Connect the Client to the requested Url.
	/// </summary>
	/// <returns>Returns True on successful connection, False on unsuccessful connection</returns>
	bool Open(Uri uri);

	/// <summary>
	///     Queue a Message to Send to the server as a String.
	/// </summary>
	/// <param name="message">The Message To Queue</param>
	/// <returns>Returns True if was successfully queued. False if it fails.</returns>
	bool Send(string message);

	/// <summary>
	///     Manually reconnects the client.
	/// </summary>
	void Reconnect();

	void MessageThrottled(OnMessageThrottledArgs args);
	void SendFailed(OnSendFailedArgs args);
	void Error(OnErrorArgs args);
}