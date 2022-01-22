using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResUserWarnDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("user_name")]
	public string UserName { get; set; } = null!;

	[JsonPropertyName("moder_id")]
	public long ModeratorId { get; set; }

	[JsonPropertyName("moder_name")]
	public string ModeratorName { get; set; } = null!;

	[JsonPropertyName("moder_rights")]
	public int ModeratorRights { get; set; }

	[JsonPropertyName("moder_premium")]
	public bool ModeratorPremium { get; set; }

	[JsonPropertyName("reason")]
	public string Reason { get; set; } = null!;
}