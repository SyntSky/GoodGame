using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Favorites;

public class RootSubscribeDto
{
	[JsonPropertyName("status")]
	public bool Status { get; set; }

	[JsonPropertyName("data")]
	public SubscribeDataDto Data { get; set; } = null!;
}