using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqRandomResultDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("success")]
	public bool Success { get; set; }

	[JsonPropertyName("data")]
	public ReqRandomResultDataDto Data { get; set; } = null!;
}