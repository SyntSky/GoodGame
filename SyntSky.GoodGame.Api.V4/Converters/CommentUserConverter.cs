using System.Text.Json;
using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Dto.Comments;

namespace SyntSky.GoodGame.Api.V4.Converters;

public class CommentUserConverter : JsonConverter<UserDto>
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeof(UserDto).IsAssignableFrom(typeToConvert);
	}

	public override UserDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.StartArray)
		{
			reader.Skip();
			return null;
		}

		return (UserDto) JsonSerializer.Deserialize(ref reader, typeToConvert)!;
	}

	public override void Write(Utf8JsonWriter writer, UserDto value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}