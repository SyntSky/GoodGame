using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.Users;

public class RoomDto
{
	[JsonPropertyName("userId")]
	public long UserId { get; set; }

	[JsonPropertyName("style")]
	public int Style { get; set; }

	[JsonPropertyName("walls")]
	public List<string> Walls { get; set; }

	[JsonPropertyName("exp")]
	public int Exp { get; set; }

	[JsonPropertyName("level")]
	public int Level { get; set; }

	[JsonPropertyName("snapshot")]
	public string Snapshot { get; set; } = null!;

	[JsonPropertyName("items")]
	public List<ItemDto>? Items { get; set; }
}