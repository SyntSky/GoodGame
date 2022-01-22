using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

public class NewsAuthorDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; }

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("iconId")]
	public long IconId { get; set; }

	[JsonPropertyName("firstname")]
	public string Firstname { get; set; }

	[JsonPropertyName("lastname")]
	public string Lastname { get; set; }

	[JsonPropertyName("birthday")]
	public string Birthday { get; set; }

	[JsonPropertyName("birthdayUTC")]
	public long BirthdayUtc { get; set; }

	[JsonPropertyName("flag")]
	public string Flag { get; set; }

	[JsonPropertyName("country")]
	public string Country { get; set; }

	[JsonPropertyName("timezone")]
	public string Timezone { get; set; }

	[JsonPropertyName("city")]
	public object City { get; set; }

	[JsonPropertyName("sex")]
	public long Sex { get; set; }

	[JsonPropertyName("site")]
	public string Site { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("image")]
	public string Image { get; set; }

	[JsonPropertyName("hide_adult")]
	public long HideAdult { get; set; }

	[JsonPropertyName("obj_key")]
	public string ObjKey { get; set; }

	[JsonPropertyName("online")]
	public bool Online { get; set; }

	[JsonPropertyName("regDate")]
	public string RegDate { get; set; }

	[JsonPropertyName("is_banned")]
	public bool IsBanned { get; set; }

	[JsonPropertyName("privacy")]
	public Dictionary<string, int> Privacy { get; set; }
}