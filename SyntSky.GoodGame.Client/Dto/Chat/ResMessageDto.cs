using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResMessageDto : IChatMessage
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("user_name")]
	public string UserName { get; set; } = null!;

	[JsonPropertyName("user_rights")]
	public int UserRights { get; set; }

	[JsonPropertyName("premium")]
	public int Premium { get; set; }

	[JsonPropertyName("premiums")]
	public List<long> Premiums { get; set; } = null!;

	[JsonPropertyName("resubs")]
	public Dictionary<string, long> ReSubs { get; set; } = null!;

	[JsonPropertyName("staff")]
	public int Staff { get; set; }

	[JsonPropertyName("color")]
	public string Color { get; set; } = null!;

	[JsonPropertyName("icon")]
	public string Icon { get; set; } = null!;

	[JsonPropertyName("role")]
	public string Role { get; set; } = null!;

	[JsonPropertyName("mobile")]
	public int Mobile { get; set; }

	[JsonPropertyName("payments")]
	public int Payments { get; set; }

	[JsonPropertyName("paymentsAll")]
	public Dictionary<string, int> PaymentsAll { get; set; } = null!;

	[JsonPropertyName("gg_plus_tier")]
	public int GgPlusTier { get; set; }

	[JsonPropertyName("isStatus")]
	public int IsStatus { get; set; }

	[JsonPropertyName("message_id")]
	public long MessageId { get; set; }

	[JsonPropertyName("timestamp")]
	public DateTimeOffset Timestamp { get; set; }

	[JsonPropertyName("regtime")]
	public DateTimeOffset? RegTime { get; set; }

	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;
}