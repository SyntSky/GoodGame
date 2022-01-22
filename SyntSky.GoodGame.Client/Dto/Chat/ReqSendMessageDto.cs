using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqSendMessageDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }

	[JsonPropertyName("color")]
	public string Color { get; set; } = null!;

	[JsonPropertyName("icon")]
	public string Icon { get; set; } = null!;

	[JsonPropertyName("mobile")]
	public int Mobile { get; set; }

	[JsonPropertyName("role")]
	public string Role { get; set; } = null!;

	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;
}