using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Help;

public class SectionBase
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;
}