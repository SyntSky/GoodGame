using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResPaymentDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("userName")]
	public string UserName { get; set; } = null!;

	[JsonPropertyName("amount")]
	public string Amount { get; set; } = null!;

	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;

	[JsonPropertyName("total")]
	public long Total { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;
}