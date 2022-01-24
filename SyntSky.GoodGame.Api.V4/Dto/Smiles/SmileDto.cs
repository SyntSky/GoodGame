using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Smiles;

public class SmileDto
{
	[JsonPropertyName("id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long Id { get; set; }

	[JsonPropertyName("key")]
	public string Key { get; set; }

	[JsonPropertyName("level")]
	public long Level { get; set; }

	[JsonPropertyName("paid")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Paid { get; set; }

	[JsonPropertyName("bind")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int Bind { get; set; }

	[JsonPropertyName("internal_id")]
	public long InternalId { get; set; }

	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }

	[JsonPropertyName("channel")]
	public string Channel { get; set; }

	[JsonPropertyName("nickname")]
	public string Nickname { get; set; }

	[JsonPropertyName("donat")]
	public long Donat { get; set; }

	[JsonPropertyName("premium")]
	public int Premium { get; set; }

	[JsonPropertyName("animated")]
	public int Animated { get; set; }

	[JsonPropertyName("images")]
	public ImageDto Images { get; set; } = null!;
}