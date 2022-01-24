using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class CommentDto
{
	[JsonPropertyName("i")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Index { get; set; }

	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long UserId { get; set; }

	[JsonPropertyName("deleted")]
	public bool Deleted { get; set; }

	[JsonPropertyName("date")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Date { get; set; }

	[JsonPropertyName("rating")]
	public RatingDto Rating { get; set; }

	[JsonPropertyName("parent")]
	public string Parent { get; set; }

	[JsonPropertyName("deleted_by")]
	public object? DeletedBy { get; set; }

	[JsonPropertyName("text")]
	public string? Text { get; set; }

	[JsonPropertyName("author")]
	public AuthorDto? Author { get; set; }
}