using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqRandomResultDataDto
{
	[JsonPropertyName("baninfo")]
	public bool Baninfo { get; set; }

	[JsonPropertyName("banned")]
	public bool Banned { get; set; }

	[JsonPropertyName("hidden")]
	public long Hidden { get; set; }

	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; } = null!;

	[JsonPropertyName("payments")]
	public long Payments { get; set; }

	[JsonPropertyName("premium")]
	public long Premium { get; set; }

	[JsonPropertyName("premiums")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public List<long> Premiums { get; set; } = null!;

	[JsonPropertyName("resubs")]
	public Dictionary<string, long> ReSubs { get; set; } = null!;

	[JsonPropertyName("rights")]
	public int Rights { get; set; }

	[JsonPropertyName("staff")]
	public int Staff { get; set; }

	[JsonPropertyName("regtime")]
	public long Regtime { get; set; }

	[JsonPropertyName("ggPlusTier")]
	public int GgPlusTier { get; set; }

	[JsonPropertyName("role")]
	public string Role { get; set; } = null!;
}