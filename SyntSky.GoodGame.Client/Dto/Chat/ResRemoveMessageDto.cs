using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResRemoveMessageDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("message_id")]
	public long MessageId { get; set; }

	[JsonPropertyName("adminName")]
	public string AdminName { get; set; } = null!;
}