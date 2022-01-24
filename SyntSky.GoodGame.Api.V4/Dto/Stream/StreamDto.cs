using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Stream;

public class StreamDto
{
	[JsonPropertyName("streams")]
	public List<ChannelDetailDto> Streams { get; set; } = null!;

	[JsonPropertyName("queryInfo")]
	public QueryInfoDto QueryInfo { get; set; } = null!;
}