using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

public class TopicDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("forum")]
	public long Forum { get; set; }

	[JsonPropertyName("forumTitle")]
	public string ForumTitle { get; set; } = null!;

	[JsonPropertyName("link")]
	public Uri Link { get; set; } = null!;

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("status")]
	public int Status { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;

	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;

	[JsonPropertyName("plainText")]
	public string PlainText { get; set; } = null!;

	[JsonPropertyName("pinned")]
	public int Pinned { get; set; }

	[JsonPropertyName("qty")]
	public int Qty { get; set; }

	[JsonPropertyName("views")]
	public int Views { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; } = null!;

	[JsonPropertyName("poll")]
	public int Poll { get; set; }

	[JsonPropertyName("deleted_by")]
	public object? DeletedBy { get; set; }

	[JsonPropertyName("rating")]
	public RatingDto Rating { get; set; } = null!;

	[JsonPropertyName("hasAccess")]
	public bool HasAccess { get; set; }

	[JsonPropertyName("isAdmin")]
	public bool IsAdmin { get; set; }

	[JsonPropertyName("creator")]
	public CreatorDto Creator { get; set; } = null!;

	[JsonPropertyName("author")]
	public string Author { get; set; } = null!;

	[JsonPropertyName("utc_date")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long UtcDate { get; set; }

	[JsonPropertyName("firstComment")]
	public CommentDto FirstComment { get; set; } = null!;

	[JsonPropertyName("lastComment")]
	public CommentDto LastComment { get; set; } = null!;
}