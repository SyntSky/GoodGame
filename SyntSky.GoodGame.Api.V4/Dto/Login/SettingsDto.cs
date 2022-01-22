using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Login;

public class SettingsDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("link")]
	public Uri Link { get; set; } = null!;
}