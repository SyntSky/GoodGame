using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResNewPollDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("answers")]
	public List<ResAnswerDto> Answers { get; set; } = null!;

	[JsonPropertyName("moder_id")]
	public long ModerId { get; set; }

	[JsonPropertyName("moder_name")]
	public string ModerName { get; set; } = null!;
}