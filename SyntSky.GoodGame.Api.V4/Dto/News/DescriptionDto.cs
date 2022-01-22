using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

public class DescriptionDto
{
	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("short_description")]
	public string ShortDescription { get; set; }

	[JsonPropertyName("update")]
	public string Update { get; set; }
}