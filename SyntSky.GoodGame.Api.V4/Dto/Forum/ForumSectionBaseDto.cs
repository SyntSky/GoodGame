using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum;

public class ForumSectionBaseDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("class")]
	public string Class { get; set; } = null!;

	[JsonPropertyName("link")]
	public Uri Link { get; set; } = null!;

	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;

	[JsonPropertyName("topicsCnt")]
	public int TopicsCnt { get; set; }

	[JsonPropertyName("postsCnt")]
	public int PostsCnt { get; set; }
}