using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Smiles;

public class ImageDto
{
	[JsonPropertyName("small")]
	public Uri Small { get; set; } = null!;

	[JsonPropertyName("big")]
	public Uri Big { get; set; } = null!;

	[JsonPropertyName("gif")]
	public Uri? Gif { get; set; }
}