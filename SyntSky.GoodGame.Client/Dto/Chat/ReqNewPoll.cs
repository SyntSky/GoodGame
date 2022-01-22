using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqNewPoll : IChatDto
{
	[JsonPropertyName("answers")]
	public List<ReqNewPollAnswer> Answers { get; set; } = null!;

	[JsonPropertyName("voters")]
	public int Voters { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }
}