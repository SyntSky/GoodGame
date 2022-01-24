using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class RootUserDto
{
	[JsonPropertyName("admin")]
	public long Admin { get; set; }

	[JsonPropertyName("user")]
	public UserDto User { get; set; }

	[JsonPropertyName("rights")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Rights { get; set; }

	[JsonPropertyName("country")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Country { get; set; }

	[JsonPropertyName("city")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int City { get; set; }

	[JsonPropertyName("phone")]
	public string Phone { get; set; }
}