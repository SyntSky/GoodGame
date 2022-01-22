using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto.Chat;

public class ResJobDto : IChatDto
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("creator")]
	public ResUserDto Creator { get; set; } = null!;

	[JsonPropertyName("created")]
	public DateTimeOffset Created { get; set; }

	[JsonPropertyName("status")]
	public long Status { get; set; }

	[JsonPropertyName("user")]
	public ResUserDto User { get; set; } = null!;

	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;

	[JsonPropertyName("updated")]
	public DateTimeOffset Updated { get; set; }

	[JsonPropertyName("started")]
	public DateTimeOffset Started { get; set; }

	[JsonPropertyName("donators")]
	public List<ResDonatorDto> Donators { get; set; } = null!;

	[JsonPropertyName("amount")]
	public long Amount { get; set; }

	[JsonPropertyName("paid")]
	public bool Paid { get; set; }

	[JsonPropertyName("pin")]
	public bool Pin { get; set; }

	[JsonPropertyName("goal")]
	public long Goal { get; set; }
}