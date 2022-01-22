using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class AuthorDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; } = null!;

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; } = null!;

	[JsonPropertyName("icon")]
	public string Icon { get; set; } = null!;

	[JsonPropertyName("owner")]
	public bool Owner { get; set; }

	[JsonPropertyName("room")]
	public RoomDto Room { get; set; } = null!;

	[JsonPropertyName("premiums")]
	public PremiumsDto Premiums { get; set; } = null!;
}