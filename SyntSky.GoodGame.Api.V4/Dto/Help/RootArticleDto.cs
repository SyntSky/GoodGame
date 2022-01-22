using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Help;

public class RootArticleDto
{
	[JsonPropertyName("article")]
	public ArticleDto Article { get; set; }

	[JsonPropertyName("types")]
	public Dictionary<string, string> Types { get; set; }
}