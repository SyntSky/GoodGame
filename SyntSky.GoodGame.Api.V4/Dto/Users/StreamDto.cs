using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class StreamDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("key")]
	public string Key { get; set; }

	[JsonPropertyName("preview")]
	public string Preview { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("viewers")]
	public int Viewers { get; set; }

	// [JsonPropertyName("streamer")]
	// public Streamer Streamer { get; set; }

	[JsonPropertyName("streamKey")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long StreamKey { get; set; }

	[JsonPropertyName("status")]
	public int Status { get; set; }

	[JsonPropertyName("game")]
	public GameDto Game { get; set; }

	[JsonPropertyName("poster")]
	public Uri Poster { get; set; }

	[JsonPropertyName("hidden")]
	public bool Hidden { get; set; }

	[JsonPropertyName("adult")]
	public bool Adult { get; set; }

	[JsonPropertyName("hosting")]
	public StreamDto? Hosting { get; set; }

	[JsonPropertyName("lastseen")]
	public long? Lastseen { get; set; }

	[JsonPropertyName("premiums")]
	public long Premiums { get; set; }

	[JsonPropertyName("followers")]
	public long Followers { get; set; }

	[JsonPropertyName("rating")]
	public RatingDto Rating { get; set; }
}