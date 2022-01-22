using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

public class CommentDto
{
	[JsonPropertyName("utc_date")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long UtcDate { get; set; }

	[JsonPropertyName("author")]
	public string Author { get; set; } = null!;

	[JsonPropertyName("authorLink")]
	public Uri AuthorLink { get; set; } = null!;

	[JsonPropertyName("authorId")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long? AuthorId { get; set; }
}