namespace SyntSky.GoodGame.Communication.Interfaces;

public interface IClientOptions
{
	int MessagesAllowedInPeriod { get; set; }

	int ReceiveMessageBufferSize { get; set; }

	bool IsAutoReconnect { get; set; }

	TimeSpan SendCacheItemTimeout { get; set; }

	ushort SendDelay { get; set; }

	int SendQueueCapacity { get; set; }

	TimeSpan ThrottlingPeriod { get; set; }

	bool UseSsl { get; set; }
}