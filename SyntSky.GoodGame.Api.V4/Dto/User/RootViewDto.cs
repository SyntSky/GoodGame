using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class RootViewDto
{
	[JsonPropertyName("user")]
	public UserDto User { get; set; }

	[JsonPropertyName("stream")]
	public StreamDto Stream { get; set; }
}