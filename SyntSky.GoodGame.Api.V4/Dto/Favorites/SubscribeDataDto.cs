using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Favorites;

public class SubscribeDataDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("get_email")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int GetEmail { get; set; }

	[JsonPropertyName("get_anons")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int GetAnons { get; set; }

	[JsonPropertyName("get_videos")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int GetVideos { get; set; }

	[JsonPropertyName("get_push")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int GetPush { get; set; }

	[JsonPropertyName("obj")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Obj { get; set; }
}