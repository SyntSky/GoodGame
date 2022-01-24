using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResPrivateMessageDto : IChatMessage
{
	[JsonPropertyName("private")]
	public long Private { get; set; }

	[JsonPropertyName("user")]
	public ResUserDto User { get; set; } = null!;

	[JsonPropertyName("to")]
	public ResUserDto To { get; set; } = null!;

	[JsonPropertyName("banned")]
	public bool Banned { get; set; }

	[JsonPropertyName("channel")]
	public long Channel { get; set; }

	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;
}