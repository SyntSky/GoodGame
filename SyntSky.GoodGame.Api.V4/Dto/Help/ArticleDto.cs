using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Help;

public class ArticleDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("type")]
	public int Type { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("text")]
	public string Text { get; set; }

	[JsonPropertyName("plainText")]
	public string PlainText { get; set; }

	[JsonPropertyName("keywords")]
	public string Keywords { get; set; }

	[JsonPropertyName("date")]
	[JsonConverter(typeof(DateTimeOffsetConverter))]
	public DateTimeOffset Date { get; set; }

	[JsonPropertyName("section")]
	[JsonConverter(typeof(NullObjectAtFalseConverter<SectionBase>))]
	public SectionBase? Section { get; set; }

	[JsonPropertyName("status")]
	public long Status { get; set; }
}