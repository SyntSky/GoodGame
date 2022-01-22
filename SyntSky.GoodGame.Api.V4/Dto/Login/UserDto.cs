using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Login;

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

	[JsonPropertyName("token")]
	public string Token { get; set; } = null!;

	[JsonPropertyName("channel")]
	public ChannelDto Channel { get; set; } = null!;

	[JsonPropertyName("settings")]
	public SettingsDto Settings { get; set; } = null!;

	[JsonPropertyName("dialogs")]
	public int Dialogs { get; set; }

	[JsonPropertyName("bl")]
	public bool Bl { get; set; }

	[Obsolete("Unknown parameter")]
	[JsonPropertyName("bl_data")]
	public List<object> BlData { get; set; } = null!;

	[JsonPropertyName("rights")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Rights { get; set; }

	[JsonPropertyName("premium")]
	public bool Premium { get; set; }

	[Obsolete("Unknown parameter")]
	[JsonPropertyName("timezone")]
	public object? Timezone { get; set; }

	[JsonPropertyName("is_banned")]
	public bool IsBanned { get; set; }

	[JsonPropertyName("jwt")]
	public string Jwt { get; set; } = null!;
}