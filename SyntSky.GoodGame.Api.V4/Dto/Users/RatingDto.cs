using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class RatingDto
{
	[JsonPropertyName("value")]
	public long Value { get; set; }

	[JsonPropertyName("place")]
	public long Place { get; set; }
}