using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Streams;

public class GenreDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("ru")]
	public string Ru { get; set; } = null!;

	[JsonPropertyName("add")]
	public string Add { get; set; } = null!;

	[JsonPropertyName("cover")]
	public string Cover { get; set; } = null!;

	[JsonPropertyName("status")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Status { get; set; }

	[JsonPropertyName("url")]
	public string? Url { get; set; }

	[JsonPropertyName("_channels")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int? Channels { get; set; }
}