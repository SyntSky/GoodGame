using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Stream;

public class ChannelDetailDto : ChannelDto
{
	[JsonPropertyName("online")]
	public int Online { get; set; }

	[JsonPropertyName("broadcast")]
	[JsonConverter(typeof(NullObjectAtFalseConverter<BroadcastDto>))]
	public BroadcastDto? Broadcast { get; set; }

	[JsonPropertyName("hosting")]
	[JsonConverter(typeof(NullObjectAtFalseConverter<ChannelDetailDto>))]
	public ChannelDetailDto? Hosting { get; set; }

	[JsonPropertyName("last_online")]
	public string LastOnline { get; set; }

	[JsonPropertyName("stream_title")]
	public string StreamTitle { get; set; }

	[JsonPropertyName("premiums")]
	public int Premiums { get; set; }

	[JsonPropertyName("followers")]
	public int Followers { get; set; }

	[JsonPropertyName("allow_comments")]
	public int AllowComments { get; set; }
}