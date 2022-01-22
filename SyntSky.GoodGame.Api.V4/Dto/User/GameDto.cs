using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class GameDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("poster")]
	public string Poster { get; set; }

	[JsonPropertyName("poster3d")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Poster3D { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }
}