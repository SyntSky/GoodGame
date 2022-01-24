using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class ItemDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("image")]
	public Uri Image { get; set; } = null!;

	[JsonPropertyName("type")]
	public int Type { get; set; }

	[JsonPropertyName("slotId")]
	public long SlotId { get; set; }
}