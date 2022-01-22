using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class CountryDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("code")]
	public string Code { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }
}