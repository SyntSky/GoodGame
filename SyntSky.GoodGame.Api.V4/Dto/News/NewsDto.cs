using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

public class NewsDto : NewsBaseDto
{
	[JsonPropertyName("description")]
	public DescriptionDto Description { get; set; }

	[JsonPropertyName("key")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Key { get; set; }

	[JsonIgnore]
	public override string Update
	{
		get => Description.Update;
		set => Description.Update = value;
	}
}