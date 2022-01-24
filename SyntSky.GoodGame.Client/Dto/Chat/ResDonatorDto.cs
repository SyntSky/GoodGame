using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResDonatorDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("amount")]
	public long Amount { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; } = null!;
}