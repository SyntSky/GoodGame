using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class UserDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; }

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; }

	[JsonPropertyName("firstname")]
	public string Firstname { get; set; }

	[JsonPropertyName("lastname")]
	public string Lastname { get; set; }

	[JsonPropertyName("fullname")]
	public string Fullname { get; set; }

	[JsonPropertyName("birthday")]
	public DateTimeOffset Birthday { get; set; }

	[JsonPropertyName("regdate")]
	public DateTimeOffset Regdate { get; set; }

	[JsonPropertyName("country")]
	public CountryDto Country { get; set; }

	[JsonPropertyName("city")]
	public CityDto City { get; set; }

	[JsonPropertyName("sex")]
	public int Sex { get; set; }

	[JsonPropertyName("website")]
	public Uri Website { get; set; }

	[JsonPropertyName("about")]
	public string About { get; set; }

	[JsonPropertyName("background")]
	public string Background { get; set; }

	[JsonPropertyName("timezone")]
	public TimezoneDto Timezone { get; set; }

	[JsonPropertyName("activated")]
	public int Activated { get; set; }

	[JsonPropertyName("stream")]
	public StreamDto Stream { get; set; }

	[JsonPropertyName("room")]
	public RoomDto Room { get; set; }

	[JsonPropertyName("bnet")]
	public string Bnet { get; set; }
}