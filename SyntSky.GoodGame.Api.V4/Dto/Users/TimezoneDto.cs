using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class TimezoneDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("zone")]
	public string? Zone { get; set; }
}