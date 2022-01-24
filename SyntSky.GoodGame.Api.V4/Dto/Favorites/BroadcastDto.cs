using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Favorites;

public class BroadcastDto
{
	[JsonPropertyName("start")]
	public int Start { get; set; }

	[JsonPropertyName("game")]
	public string Game { get; set; } = null!;

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;
}