using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class ChannelDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("link")]
	public string Link { get; set; } = null!;

	[JsonPropertyName("streamer")]
	public string Streamer { get; set; } = null!;

	[JsonPropertyName("avatar")]
	public string? Avatar { get; set; }

	[JsonPropertyName("hidden")]
	public string? Hidden { get; set; }

	[JsonPropertyName("game")]
	public string Game { get; set; } = null!;

	[JsonPropertyName("viewers")]
	public int Viewers { get; set; }

	[JsonPropertyName("preview")]
	public string Preview { get; set; } = null!;

	[JsonPropertyName("poster")]
	public string Poster { get; set; } = null!;

	[JsonPropertyName("premium")]
	[JsonConverter(typeof(BoolConverter))]
	public bool Premium { get; set; }

	[JsonPropertyName("streamkey")]
	public string StreamKey { get; set; } = null!;

	[JsonPropertyName("channelkey")]
	public string? ChannelKey { get; set; }

	[JsonPropertyName("status")]
	public bool Status { get; set; }

	[JsonPropertyName("favorite")]
	public object? Favorite { get; set; }

	[JsonPropertyName("sources")]
	public SourcesDto? Sources { get; set; }
}