using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class GamesListDto
{
	[JsonPropertyName("list")]
	public List<GameDto> List { get; set; }

	[JsonPropertyName("total")]
	public long Total { get; set; }
}