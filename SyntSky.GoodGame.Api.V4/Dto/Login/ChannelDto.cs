using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Login;

public class ChannelDto
{
	[JsonPropertyName("chat")]
	public ChatDto Chat { get; set; } = null!;

	[JsonPropertyName("beta")]
	public Dictionary<string, long> Beta { get; set; } = null!;
}