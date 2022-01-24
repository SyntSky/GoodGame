using System.Text.Json;
using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Converters;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
	public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.TokenType switch
		{
			JsonTokenType.String => JsonSerializer.Deserialize<DateTimeOffset>(ref reader, options),
			JsonTokenType.Number => DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64()),
			_ => throw new JsonException()
		};
	}

	public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}