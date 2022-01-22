using System.Text.Json;
using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Dto.News;

namespace SyntSky.GoodGame.Api.V4.Converters;

public class NewsConverter : JsonConverter<NewsBaseDto>
{
	public override NewsBaseDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject)
			throw new JsonException("Expected StartObject token");

		NewsBaseDto? newsBaseDto = null;

		long id = 0;
		var cqty = 0;
		var logo = string.Empty;
		var views = 0;


		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
			{
				newsBaseDto!.Id = id;
				newsBaseDto.Cqty = cqty;
				newsBaseDto.Logo = logo;
				newsBaseDto.Views = views;
				return newsBaseDto;
			}

			if (reader.TokenType != JsonTokenType.PropertyName)
				throw new JsonException("Expected PropertyName token");

			var propName = reader.GetString();
			reader.Read();

			switch (propName)
			{
				case "id":
					id = JsonSerializer.Deserialize<long>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;
				case "cqty":
					cqty = JsonSerializer.Deserialize<int>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;
				case "logo":
					logo = reader.GetString()!;
					break;
				case "views":
					views = JsonSerializer.Deserialize<int>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;


				case "key":
					newsBaseDto ??= new NewsDto();
					((NewsDto) newsBaseDto).Key = JsonSerializer.Deserialize<long>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;
				case "description":
					newsBaseDto ??= new NewsDto();
					((NewsDto) newsBaseDto).Description =
						JsonSerializer.Deserialize<DescriptionDto>(ref reader, options)!;
					break;


				case "status":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Status = reader.GetInt32();
					break;
				case "started":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Started = reader.GetBoolean();
					break;
				case "closed":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Closed = reader.GetInt32();
					break;
				case "title":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Title = reader.GetString()!;
					break;
				case "game":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Game = reader.GetString()!;
					break;
				case "gameTitle":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).GameTitle = reader.GetString()!;
					break;
				case "color":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Color = reader.GetString()!;
					break;
				case "start":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Start = DateTimeOffset.FromUnixTimeSeconds(
						JsonSerializer.Deserialize<long>(ref reader,
							new JsonSerializerOptions(options)
							{
								NumberHandling = JsonNumberHandling.AllowReadingFromString
							}));
					break;
				case "prize_fund":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).PrizeFund = reader.GetString()!;
					break;
				case "participants":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Participants = reader.GetInt32();
					break;
				case "participants_type":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).ParticipantsType = JsonSerializer.Deserialize<int>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;
				case "mine":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).Mine = reader.GetBoolean();
					break;
				case "prize_places":
					newsBaseDto ??= new NewsCupDto();
					((NewsCupDto) newsBaseDto).PrizePlaces = JsonSerializer.Deserialize<int>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;


				case "date":
					switch (newsBaseDto)
					{
						case NewsCupDto:
							newsBaseDto.Date = DateTimeOffset.FromUnixTimeSeconds(JsonSerializer.Deserialize<long>(
								ref reader,
								new JsonSerializerOptions(options)
								{
									NumberHandling = JsonNumberHandling.AllowReadingFromString
								}));
							break;
						case NewsDto:
							newsBaseDto.Date = JsonSerializer.Deserialize<DateTimeOffset>(ref reader, options);
							break;
						default:
							throw new ArgumentOutOfRangeException(nameof(newsBaseDto));
					}

					break;
			}
		}

		throw new JsonException("Expected EndObject token");
	}

	public override void Write(Utf8JsonWriter writer, NewsBaseDto value, JsonSerializerOptions options)
	{
		var type = value.GetType();
		JsonSerializer.Serialize(writer, value, type, options);
	}
}