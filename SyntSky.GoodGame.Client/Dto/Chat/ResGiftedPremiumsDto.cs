using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResGiftedPremiumsDto : IChatDto
{
	[JsonPropertyName("channel_id")]
	public long ChannelId { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("payer")]
	public string Payer { get; set; } = null!;

	[JsonPropertyName("users")]
	public List<ResGiftedPremiumsUserDto> Users { get; set; } = null!;
}