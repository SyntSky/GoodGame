using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class SourcesDto
{
	[JsonPropertyName("240")]
	public Uri The240 { get; set; }

	[JsonPropertyName("480")]
	public Uri The480 { get; set; }

	[JsonPropertyName("720")]
	public Uri The720 { get; set; }

	[JsonPropertyName("source")]
	public Uri Source { get; set; }

	[JsonPropertyName("smil")]
	public Uri Smil { get; set; }
}