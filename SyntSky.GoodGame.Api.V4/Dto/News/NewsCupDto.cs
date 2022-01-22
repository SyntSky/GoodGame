using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Dto.News;

public class NewsCupDto : NewsBaseDto
{
	[JsonPropertyName("update")]
	public override string Update { get; set; }

	[JsonPropertyName("status")]
	public int Status { get; set; }

	[JsonPropertyName("started")]
	public bool Started { get; set; }

	[JsonPropertyName("closed")]
	public int Closed { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("game")]
	public string Game { get; set; }

	[JsonPropertyName("gameTitle")]
	public string GameTitle { get; set; }

	[JsonPropertyName("color")]
	public string Color { get; set; }

	[JsonPropertyName("start")]
	public DateTimeOffset Start { get; set; }

	[JsonPropertyName("prize_fund")]
	public string PrizeFund { get; set; }

	[JsonPropertyName("participants")]
	public int Participants { get; set; }

	[JsonPropertyName("participants_type")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int ParticipantsType { get; set; }

	[JsonPropertyName("mine")]
	public bool Mine { get; set; }

	[JsonPropertyName("prize_places")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
	public int PrizePlaces { get; set; }
}