using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Converters;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResSettingDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;

	[JsonPropertyName("value")]
	public string Value { get; set; } = null!;

	[JsonPropertyName("moder_id")]
	public long ModerId { get; set; }

	[JsonPropertyName("moder_name")]
	public string ModerName { get; set; } = null!;

	[JsonPropertyName("moder_rights")]
	public int ModerRights { get; set; }

	[JsonPropertyName("moder_premium")]
	[JsonConverter(typeof(BoolConverter))]
	public bool ModerPremium { get; set; }

	[JsonPropertyName("silent")]
	public int Silent { get; set; }
}