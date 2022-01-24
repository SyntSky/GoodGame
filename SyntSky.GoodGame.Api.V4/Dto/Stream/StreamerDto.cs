using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Stream;

public class StreamerDto
{
	[JsonPropertyName("nickname")]
	public string Nickname { get; set; } = null!;

	[JsonPropertyName("avatar")]
	public string? Avatar { get; set; }
}