using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

[JsonConverter(typeof(NewsConverter))]
public abstract class NewsBaseDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("cqty")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Cqty { get; set; }

	[JsonPropertyName("logo")]
	public string Logo { get; set; }

	[JsonPropertyName("views")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Views { get; set; }

	[JsonPropertyName("date")]
	[JsonConverter(typeof(DateTimeOffsetConverter))]
	public DateTimeOffset Date { get; set; }

	public abstract string Update { get; set; }
}