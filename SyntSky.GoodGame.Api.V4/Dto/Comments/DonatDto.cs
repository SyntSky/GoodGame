using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class DonatDto
{
	[JsonPropertyName("objId")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("level")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Level { get; set; }

	[JsonPropertyName("key")]
	public string ChannelName { get; set; } = null!;
}