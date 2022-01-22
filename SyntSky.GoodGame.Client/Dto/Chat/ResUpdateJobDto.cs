using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResUpdateJobDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }

	[JsonPropertyName("job")]
	public ResJobDto Job { get; set; } = null!;
}