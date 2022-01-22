using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class SourcesDto
{
	[JsonPropertyName("240")]
	public string The240 { get; set; }

	[JsonPropertyName("480")]
	public string The480 { get; set; }

	[JsonPropertyName("720")]
	public string The720 { get; set; }

	[JsonPropertyName("source")]
	public string Source { get; set; }

	[JsonPropertyName("smil")]
	public string Smil { get; set; }
}