using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class PremiumDto
{
	[JsonPropertyName("channel")]
	public string ChannelId { get; set; }

	[JsonPropertyName("channel_obj")]
	public ChannelDto? Channel { get; set; }

	[JsonPropertyName("days_left")]
	public long DaysLeft { get; set; }
}