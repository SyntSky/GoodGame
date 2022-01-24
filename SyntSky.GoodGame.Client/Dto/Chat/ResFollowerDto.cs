using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResFollowerDto : IChatDto
{
	[JsonPropertyName("userId")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long UserId { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; } = null!;

	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }
}