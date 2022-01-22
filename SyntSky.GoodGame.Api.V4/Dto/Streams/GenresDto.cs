using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Streams;

public class GenresDto
{
	[JsonPropertyName("genres")]
	public List<GenreDto> Genres { get; set; } = null!;

	[JsonPropertyName("total")]
	public string Total { get; set; } = null!;
}