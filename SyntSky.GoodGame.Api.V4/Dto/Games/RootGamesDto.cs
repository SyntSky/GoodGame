using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class RootGamesDto
{
	[JsonPropertyName("games")]
	public GamesDto Games { get; set; } = null!;

	[JsonPropertyName("genres")]
	public List<GenreDto> Genres { get; set; } = null!;

	[JsonPropertyName("groups")]
	public List<GroupDto> Groups { get; set; } = null!;

	[JsonPropertyName("platforms")]
	public List<PlatformDto> Platforms { get; set; } = null!;
}