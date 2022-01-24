using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResSuccessJoinDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("channel_name")]
	public string ChannelName { get; set; } = null!;

	// [JsonPropertyName("channel_streamer")]
	// public ChannelStreamer ChannelStreamer { get; set; }

	[JsonPropertyName("motd")]
	public string Motd { get; set; } = null!;

	[JsonPropertyName("room_type")]
	public string RoomType { get; set; } = null!;

	[JsonPropertyName("room_premium")]
	public bool RoomPremium { get; set; }

	[JsonPropertyName("premium_price")]
	public int PremiumPrice { get; set; }

	[JsonPropertyName("donate_buttons")]
	public string DonateButtons { get; set; } = null!;

	[JsonPropertyName("clients_in_channel")]
	public int ClientsInChannel { get; set; }

	[JsonPropertyName("users_in_channel")]
	public int UsersInChannel { get; set; }

	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;

	[JsonPropertyName("access_rights")]
	public int AccessRights { get; set; }

	[JsonPropertyName("premium_only")]
	public int PremiumOnly { get; set; }

	[JsonPropertyName("premium")]
	public bool Premium { get; set; }

	[JsonPropertyName("premiums")]
	public List<string> Premiums { get; set; } = null!;

	[JsonPropertyName("notifies")]
	public Dictionary<string, int> Notifies { get; set; } = null!;

	[JsonPropertyName("resubs")]
	public Dictionary<string, int> Resubs { get; set; } = null!;

	[JsonPropertyName("gg_plus_tier")]
	public int GgPlusTier { get; set; }

	[JsonPropertyName("staff")]
	public int Staff { get; set; }

	[JsonPropertyName("is_banned")]
	public bool IsBanned { get; set; }

	[JsonPropertyName("banned_time")]
	public int BannedTime { get; set; }

	[JsonPropertyName("reason")]
	public string Reason { get; set; } = null!;

	[JsonPropertyName("permanent")]
	public bool Permanent { get; set; }

	[JsonPropertyName("payments")]
	public int Payments { get; set; }

	[JsonPropertyName("paymentsAll")]
	public Dictionary<string, int> PaymentsAll { get; set; } = null!;

	[JsonPropertyName("jobs")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Jobs { get; set; }
}