using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Login;

public class RootLoginByPassword
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }

	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;
}