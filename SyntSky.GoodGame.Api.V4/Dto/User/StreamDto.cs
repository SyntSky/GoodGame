using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.User;

public class StreamDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("link")]
	public Uri Link { get; set; }

	[JsonPropertyName("streamer")]
	public string Streamer { get; set; }

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; }

	[JsonPropertyName("hidden")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Hidden { get; set; }

	[JsonPropertyName("game")]
	public GameDto Game { get; set; }

	[JsonPropertyName("viewers")]
	public long Viewers { get; set; }

	[JsonPropertyName("preview")]
	public Uri Preview { get; set; }

	[JsonPropertyName("poster")]
	public Uri Poster { get; set; }

	[JsonPropertyName("premium")]
	public bool Premium { get; set; }

	[JsonPropertyName("streamkey")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Streamkey { get; set; }

	[JsonPropertyName("channelkey")]
	public string Channelkey { get; set; }

	[JsonPropertyName("status")]
	public bool Status { get; set; }

	[JsonPropertyName("favorite")]
	public object Favorite { get; set; }

	[JsonPropertyName("sources")]
	public SourcesDto Sources { get; set; }
}