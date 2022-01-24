using System.Text.Json;
using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Dto.Stream;

namespace SyntSky.GoodGame.Api.V4.Converters;

public class StreamerDtoAtStringConverter : JsonConverter<StreamerDto>
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeof(StreamerDto).IsAssignableFrom(typeToConvert);
	}

	public override StreamerDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
			return new StreamerDto
			{
				Nickname = reader.GetString() ?? string.Empty
			};

		return JsonSerializer.Deserialize<StreamerDto>(ref reader)!;
	}

	public override void Write(Utf8JsonWriter writer, StreamerDto value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}