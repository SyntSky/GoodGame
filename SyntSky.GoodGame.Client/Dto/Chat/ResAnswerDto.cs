using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResAnswerDto : IChatDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;

	[JsonPropertyName("voters")]
	public int Voters { get; set; }
}