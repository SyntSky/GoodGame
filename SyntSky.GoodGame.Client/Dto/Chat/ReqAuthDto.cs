using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ReqAuthDto : IChatDto
{
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("token")]
	public string Token { get; set; } = null!;
}