using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Streams;

public class GamesDto
{
	[JsonPropertyName("games")]
	public List<GameDto> Games { get; set; } = null!;

	[JsonPropertyName("total")]
	public string Total { get; set; } = null!;
}