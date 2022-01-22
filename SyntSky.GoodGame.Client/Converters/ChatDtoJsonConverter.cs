using System.Text.Json;
using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Dto;
using SyntSky.GoodGame.Client.Dto.Chat;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Converters;

public class ChatDtoJsonConverter : JsonConverter<ChatRootDto>
{
	public override ChatRootDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();


		reader.Read();

		var propertyName = reader.GetString();
		if (propertyName != "type") throw new JsonException();

		reader.Read();
		if (reader.TokenType != JsonTokenType.String) throw new JsonException();

		var type = reader.GetString()?.ToLower() ?? throw new InvalidOperationException();

		reader.Read();
		propertyName = reader.GetString();
		if (propertyName != "data") throw new JsonException();

		reader.Read();
		if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

		var desiredType = GetType(type);


		var data = JsonSerializer.Deserialize(ref reader, desiredType) as IChatDto ??
		           throw new InvalidOperationException();

		reader.Read();
		if (reader.TokenType != JsonTokenType.EndObject) throw new JsonException();

		var value = new ChatRootDto(type, data);

		return value;
	}

	public override void Write(Utf8JsonWriter writer, ChatRootDto? value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();
		if (value != null)
		{
			writer.WriteString("type", value.Type);

			writer.WritePropertyName("data");
			JsonSerializer.Serialize(writer, (object) value.Data, options);
		}

		writer.WriteEndObject();
	}

	private static Type GetType(string name)
	{
		return name switch
		{
			"welcome" => typeof(ResWelcomeDto),
			"message" => typeof(IChatMessage),
			"success_auth" => typeof(ResSuccessAuthDto),
			"channel_counters" => typeof(ResChannelCountersDto),
			"success_join" => typeof(ResSuccessJoinDto),
			"unjoin" => typeof(ResUnJoinDto),
			"follower" => typeof(ResFollowerDto),
			"payment" => typeof(ResPaymentDto),
			"premium" => typeof(ResPremiumDto),
			"user_warn" => typeof(ResUserWarnDto),
			"remove_message" => typeof(ResRemoveMessageDto),
			"gifted_premiums" => typeof(ResGiftedPremiumsDto),
			"update_channel_info" => typeof(ResUpdateChannelInfoDto),
			"new_poll" => typeof(ResNewPollDto),
			"error" => typeof(ResErrorDto),
			"user_ban" => typeof(ResUserBanDto),
			"setting" => typeof(ResSettingDto),
			"update_job" => typeof(ResUpdateJobDto),
			"random_result" => typeof(ReqRandomResultDto),

			_ => throw new JsonException($"Unable to convert \"{name}\" to \"{typeof(IChatDto)}\".")
		};
	}
}