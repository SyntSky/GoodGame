using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum;

public class ForumSectionLightDto : ForumSectionBaseDto
{
	[JsonPropertyName("subForums")]
	public List<ForumSectionBaseDto> SubForums { get; set; } = null!;

	[JsonPropertyName("topics")]
	public bool Topics { get; set; }

	[JsonPropertyName("queryInfo")]
	public bool QueryInfo { get; set; }
}