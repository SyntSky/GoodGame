using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqNewPollAnswer
{
	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;
}