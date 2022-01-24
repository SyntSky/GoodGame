using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Stream;

public class ChannelDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("link")]
	public string Link { get; set; }

	[JsonPropertyName("streamer")]
	[JsonConverter(typeof(StreamerDtoAtStringConverter))]
	public StreamerDto Streamer { get; set; }

	[JsonPropertyName("avatar")]
	public string? Avatar { get; set; }

	[JsonPropertyName("hidden")]
	public string? Hidden { get; set; }

	[JsonPropertyName("game")]
	public string Game { get; set; }

	[JsonPropertyName("viewers")]
	public int Viewers { get; set; }

	[JsonPropertyName("preview")]
	public string Preview { get; set; }

	[JsonPropertyName("poster")]
	public string Poster { get; set; }

	[JsonPropertyName("premium")]
	[JsonConverter(typeof(BoolConverter))]
	public bool Premium { get; set; }

	[JsonPropertyName("streamkey")]
	public string Streamkey { get; set; }

	[JsonPropertyName("channelkey")]
	public string? Channelkey { get; set; }

	[JsonPropertyName("status")]
	public bool Status { get; set; }

	[JsonPropertyName("favorite")]
	public object? Favorite { get; set; }

	[JsonPropertyName("sources")]
	public SourcesDto? Sources { get; set; }
}