using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

public class NewsDetailDto : NewsDto
{
	[JsonPropertyName("status")]
	public int Status { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("background")]
	public string Background { get; set; }

	[JsonPropertyName("social")]
	public string Social { get; set; }

	[JsonPropertyName("type")]
	public int Type { get; set; }

	[JsonPropertyName("source")]
	public string Source { get; set; }

	[JsonPropertyName("poll")]
	public int Poll { get; set; }

	[JsonPropertyName("author")]
	public NewsAuthorDto Author { get; set; }

	[JsonPropertyName("hasAccess")]
	public bool HasAccess { get; set; }
}