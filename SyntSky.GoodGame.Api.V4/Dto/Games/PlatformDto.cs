using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class PlatformDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("platform")]
	public string PlatformPlatform { get; set; } = null!;

	[JsonPropertyName("link")]
	public string Link { get; set; }
}