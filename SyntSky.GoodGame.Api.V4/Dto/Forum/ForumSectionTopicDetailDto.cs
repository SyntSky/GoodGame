using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum;

public class ForumSectionTopicDetailDto : ForumSectionBaseDto
{
	[JsonPropertyName("subForums")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public List<int> SubForums { get; set; } = null!;

	[JsonPropertyName("topics")]
	public List<TopicDto> Topics { get; set; }

	[JsonPropertyName("queryInfo")]
	public QueryInfoDto QueryInfo { get; set; }
}