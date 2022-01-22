using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

public class CreatorDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; }
}