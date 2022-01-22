using SyntSky.GoodGame.Communication.Interfaces;

namespace SyntSky.GoodGame.Communication.Models;

public class ClientOptions : IClientOptions
{
	public int MessagesAllowedInPeriod { get; set; } = 100;
	public int ReceiveMessageBufferSize { get; set; } = 4 * 1024;
	public bool IsAutoReconnect { get; set; }
	public TimeSpan SendCacheItemTimeout { get; set; } = TimeSpan.FromMinutes(30);
	public ushort SendDelay { get; set; } = 50;
	public int SendQueueCapacity { get; set; } = 10000;
	public TimeSpan ThrottlingPeriod { get; set; } = TimeSpan.FromSeconds(30);
	public bool UseSsl { get; set; } = true;
}