using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Emums;

namespace SyntSky.GoodGame.Api.V4.Dto.Streams;

public class GameDto
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("url")]
	public string Url { get; set; } = null!;

	[JsonPropertyName("poster")]
	public Uri Poster { get; set; } = null!;

	[JsonPropertyName("streams")]
	public int Streams { get; set; }

	[JsonPropertyName("viewers")]
	public int Viewers { get; set; }

	[JsonPropertyName("poster3d")]
	public int Poster3D { get; set; }

	[JsonPropertyName("group_type")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public GameGroupType GroupType { get; set; }
}