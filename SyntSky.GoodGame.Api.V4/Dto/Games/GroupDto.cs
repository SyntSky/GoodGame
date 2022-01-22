using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class GroupDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("maps")]
	public string Maps { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("short_name")]
	public string ShortName { get; set; }

	[JsonPropertyName("poster")]
	public Uri Poster { get; set; }

	[JsonPropertyName("poster3d")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Poster3D { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("news")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int News { get; set; }

	[JsonPropertyName("cups")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Cups { get; set; }

	[JsonPropertyName("forum")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Forum { get; set; }

	[JsonPropertyName("color")]
	public string Color { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("genres")]
	public List<GenreDto> Genres { get; set; }

	[JsonPropertyName("games")]
	public List<Dictionary<string, string>> Games { get; set; }

	[JsonPropertyName("platforms")]
	public object Platforms { get; set; }
}