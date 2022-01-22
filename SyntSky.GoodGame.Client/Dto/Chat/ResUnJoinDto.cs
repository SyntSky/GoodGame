using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResUnJoinDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	[Obsolete("Missing in new message type")]
	public long? ChannelId { get; set; }

	[JsonPropertyName("success")]
	public bool Success { get; set; }
}