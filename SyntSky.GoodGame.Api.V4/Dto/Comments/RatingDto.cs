using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class RatingDto
{
	[JsonPropertyName("up")]
	public long Up { get; set; }

	[JsonPropertyName("down")]
	public long Down { get; set; }

	[JsonPropertyName("voted")]
	public long Voted { get; set; }

	[JsonPropertyName("value")]
	public long Value { get; set; }
}