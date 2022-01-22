using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class GamesDto
{
	[JsonPropertyName("list")]
	public GamesListDto List { get; set; }

	[JsonPropertyName("total")]
	public long Total { get; set; }
}