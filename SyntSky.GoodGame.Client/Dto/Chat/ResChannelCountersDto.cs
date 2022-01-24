using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResChannelCountersDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public long ChannelId { get; set; }

	[JsonPropertyName("clients_in_channel")]
	public int ClientsInChannel { get; set; }

	[JsonPropertyName("users_in_channel")]
	public int UsersInChannel { get; set; }
}