using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class UserDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; } = null!;

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; } = null!;

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; } = null!;

	[JsonPropertyName("icon")]
	public string Icon { get; set; } = null!;

	[JsonPropertyName("iconId")]
	public long IconId { get; set; }

	[JsonPropertyName("firstname")]
	public string Firstname { get; set; } = null!;

	[JsonPropertyName("lastname")]
	public string Lastname { get; set; } = null!;

	[JsonPropertyName("birthday")]
	public string Birthday { get; set; } = null!;

	[JsonPropertyName("birthdayUTC")]
	public long BirthdayUtc { get; set; }

	[JsonPropertyName("flag")]
	public string Flag { get; set; } = null!;

	[JsonPropertyName("country")]
	public string Country { get; set; } = null!;

	[JsonPropertyName("timezone")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Timezone { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("sex")]
	public int Sex { get; set; }

	[JsonPropertyName("site")]
	public Uri Site { get; set; } = null!;

	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;

	[JsonPropertyName("image")]
	public string Image { get; set; } = null!;

	[JsonPropertyName("hide_adult")]
	public int HideAdult { get; set; }

	[JsonPropertyName("online")]
	public bool Online { get; set; }

	[JsonPropertyName("regDate")]
	public string RegDate { get; set; } = null!;

	[JsonPropertyName("is_banned")]
	public bool IsBanned { get; set; }

	[JsonPropertyName("privacy")]
	public Dictionary<string, int> Privacy { get; set; } = null!;
}