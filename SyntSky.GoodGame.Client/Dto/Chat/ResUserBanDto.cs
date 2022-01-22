using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResUserBanDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("user_name")]
	public string UserName { get; set; } = null!;

	[JsonPropertyName("moder_id")]
	public long ModerId { get; set; }

	[JsonPropertyName("moder_name")]
	public string ModerName { get; set; } = null!;

	[JsonPropertyName("moder_rights")]
	public long ModerRights { get; set; }

	[JsonPropertyName("moder_premium")]
	public bool ModerPremium { get; set; }

	[JsonPropertyName("duration")]
	public long Duration { get; set; }

	[JsonPropertyName("type")]
	public long Type { get; set; }

	[JsonPropertyName("reason")]
	public string Reason { get; set; } = null!;

	[JsonPropertyName("show")]
	public bool Show { get; set; }
}