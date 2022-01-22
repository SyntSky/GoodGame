using System.Text.Json;
using System.Text.Json.Serialization;

namespace SyntSky.GoodGame.Api.V4.Converters;

public class NullObjectAtFalseConverter<T> : JsonConverter<T>
{
	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.TokenType == JsonTokenType.False ? default : JsonSerializer.Deserialize<T>(ref reader, options);
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}