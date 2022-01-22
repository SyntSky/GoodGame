using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class PremiumsDto
{
	[JsonPropertyName("premiums")]
	public List<PremiumDto> Premiums { get; set; } = null!;

	[JsonPropertyName("donats")]
	public List<DonatDto> Donats { get; set; } = null!;
}