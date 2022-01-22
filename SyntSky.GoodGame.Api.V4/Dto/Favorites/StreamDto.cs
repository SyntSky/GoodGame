using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Favorites;

public class StreamDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("link")]
	public Uri Link { get; set; } = null!;

	[JsonPropertyName("streamer")]
	public StreamerDto Streamer { get; set; }

	[JsonPropertyName("avatar")]
	public string Avatar { get; set; } = null!;

	[JsonPropertyName("hidden")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Hidden { get; set; }

	[JsonPropertyName("game")]
	public string Game { get; set; } = null!;

	[JsonPropertyName("viewers")]
	public int Viewers { get; set; }

	[JsonPropertyName("preview")]
	public string Preview { get; set; } = null!;

	[JsonPropertyName("poster")]
	public string Poster { get; set; } = null!;

	[JsonPropertyName("premium")]
	public int Premium { get; set; }

	[JsonPropertyName("streamkey")]
	public string Streamkey { get; set; } = null!;

	[JsonPropertyName("channelkey")]
	public string Channelkey { get; set; } = null!;

	[JsonPropertyName("status")]
	public bool Status { get; set; }

	[JsonPropertyName("favorite")]
	public object Favorite { get; set; } = null!;

	[JsonPropertyName("sources")]
	public SourcesDto Sources { get; set; } = null!;

	[JsonPropertyName("online")]
	public int IsOnline { get; set; }

	[JsonPropertyName("broadcast")]
	[JsonConverter(typeof(NullObjectAtFalseConverter<BroadcastDto>))]
	public BroadcastDto? Broadcast { get; set; }

	[JsonPropertyName("hosting")]
	public bool Hosting { get; set; }

	[JsonPropertyName("last_online")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int LastOnline { get; set; }

	[JsonPropertyName("stream_title")]
	public string StreamTitle { get; set; } = null!;

	[JsonPropertyName("cqty")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Cqty { get; set; }
}