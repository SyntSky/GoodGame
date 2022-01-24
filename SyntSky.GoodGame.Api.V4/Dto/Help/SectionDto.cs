using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Help;

public class SectionDto : SectionBase
{
	[JsonPropertyName("order")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Order { get; set; }

	[JsonPropertyName("articles")]
	public List<ArticleDto> Articles { get; set; } = null!;

	[JsonPropertyName("queryInfo")]
	public QueryInfoDto? QueryInfo { get; set; }
}