using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum;

public class ForumDto
{
	[JsonPropertyName("forumSections")]
	public List<ForumSectionLightDto> ForumSections { get; set; } = null!;

	[JsonPropertyName("hotTopics")]
	public List<TopicDto> HotTopics { get; set; } = null!;
}