using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResGiftedPremiumsUserDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; } = null!;
}