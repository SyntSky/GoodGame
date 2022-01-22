using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Login;

public class ChatDto
{
	[JsonPropertyName("alignType")]
	public int AlignType { get; set; }

	[JsonPropertyName("pekaMod")]
	public int PekaMod { get; set; }

	[JsonPropertyName("sound")]
	public int Sound { get; set; }

	[JsonPropertyName("soundVolume")]
	public int SoundVolume { get; set; }

	[JsonPropertyName("smilesType")]
	public int SmilesType { get; set; }

	[JsonPropertyName("hide")]
	public int Hide { get; set; }

	[JsonPropertyName("quickBan")]
	public int QuickBan { get; set; }

	[JsonPropertyName("quickDelete")]
	public int QuickDelete { get; set; }

	[JsonPropertyName("noBan")]
	public int NoBan { get; set; }
}