using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResWelcomeDto : IChatDto
{
	[JsonPropertyName("protocolVersion")]
	public int ProtocolVersion { get; set; }
}