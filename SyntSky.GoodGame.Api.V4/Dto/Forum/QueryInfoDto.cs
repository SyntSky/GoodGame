using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum;

public class QueryInfoDto
{
	[JsonPropertyName("qty")]
	public int Qty { get; set; }

	[JsonPropertyName("page")]
	public int Page { get; set; }

	[JsonPropertyName("onPage")]
	public int OnPage { get; set; }
}