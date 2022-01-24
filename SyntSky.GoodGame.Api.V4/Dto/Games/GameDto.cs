using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Games;

public class GameDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("short")]
	public string Short { get; set; }

	[JsonPropertyName("synonym")]
	public object Synonym { get; set; }

	[JsonPropertyName("poster")]
	public Uri Poster { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("status")]
	public long Status { get; set; }

	[JsonPropertyName("poster3d")]
	public long Poster3D { get; set; }

	[JsonPropertyName("materials")]
	public long Materials { get; set; }

	[JsonPropertyName("cups")]
	public long Cups { get; set; }

	[JsonPropertyName("forum")]
	public long Forum { get; set; }

	[JsonPropertyName("streams")]
	public long Streams { get; set; }

	[JsonPropertyName("participants_type")]
	public long ParticipantsType { get; set; }

	[JsonPropertyName("team_size")]
	public long TeamSize { get; set; }

	[JsonPropertyName("color")]
	public string Color { get; set; }

	[JsonPropertyName("edited")]
	public string EditedTime { get; set; }

	[JsonPropertyName("maps")]
	public string Maps { get; set; }

	[JsonPropertyName("races")]
	public string Races { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("genres")]
	public List<GenreDto> Genres { get; set; }

	[JsonPropertyName("group")]
	[JsonConverter(typeof(NullObjectAtZeroConverter<GroupDto>))]
	public GroupDto Group { get; set; }

	[JsonPropertyName("platforms")]
	public object Platforms { get; set; }
}