using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqJoinDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }

	[JsonPropertyName("hidden")]
	public bool Hidden { get; set; }
}