using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class GenreDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("add")]
	public string Add { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("cover")]
	public Uri Cover { get; set; }

	[JsonPropertyName("ru")]
	public string Ru { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("status")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Status { get; set; }
}