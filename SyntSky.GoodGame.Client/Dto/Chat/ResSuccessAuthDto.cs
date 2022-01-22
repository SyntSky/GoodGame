using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResSuccessAuthDto : IChatDto
{
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("user_name")]
	public string UserName { get; set; } = null!;
}