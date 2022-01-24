using System.Text.Json;
using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Dto.Chat;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Converters;

public class ChatMessageDtoJsonConverter : JsonConverter<IChatMessage>
{
	public override bool CanConvert(Type type)
	{
		return typeof(IChatMessage).IsAssignableFrom(type);
	}

	public override IChatMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject)
			throw new JsonException("Expected StartObject token");

		IChatMessage? message = null;
		var messageText = string.Empty;
		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
			{
				message!.Text = messageText;
				return message;
			}

			if (reader.TokenType != JsonTokenType.PropertyName)
				throw new JsonException("Expected PropertyName token");

			var propName = reader.GetString();
			reader.Read();

			switch (propName)
			{
				case "text":
					messageText = reader.GetString()!;
					break;

				case "private":
					message ??= new ResPrivateMessageDto();
					((ResPrivateMessageDto) message).Private = reader.GetInt32();
					break;
				case "user":
					message ??= new ResPrivateMessageDto();
					((ResPrivateMessageDto) message).User =
						JsonSerializer.Deserialize<ResUserDto>(ref reader, options)!;
					break;
				case "to":
					message ??= new ResPrivateMessageDto();
					((ResPrivateMessageDto) message).To =
						JsonSerializer.Deserialize<ResUserDto>(ref reader, options)!;
					break;
				case "banned":
					message ??= new ResPrivateMessageDto();
					((ResPrivateMessageDto) message).Banned = reader.GetBoolean();
					break;
				case "channel":
					message ??= new ResPrivateMessageDto();
					((ResPrivateMessageDto) message).Channel = reader.GetInt64();
					break;

				case "channel_id":
					message ??= new ResMessageDto();
					((ResMessageDto) message).ChannelId = JsonSerializer.Deserialize<long>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						});
					break;
				case "user_id":
					message ??= new ResMessageDto();
					((ResMessageDto) message).UserId = reader.GetInt64();
					break;
				case "user_name":
					message ??= new ResMessageDto();
					((ResMessageDto) message).UserName = reader.GetString()!;
					break;
				case "user_rights":
					message ??= new ResMessageDto();
					((ResMessageDto) message).UserRights = reader.GetInt32();
					break;
				case "premium":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Premium = reader.GetInt32();
					break;
				case "premiums":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Premiums = JsonSerializer.Deserialize<List<long>>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						})!;
					break;
				case "resubs":
					message ??= new ResMessageDto();
					((ResMessageDto) message).ReSubs = JsonSerializer.Deserialize<Dictionary<string, long>>(ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						})!;
					break;
				case "staff":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Staff = reader.GetInt32();
					break;
				case "color":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Color = reader.GetString()!;
					break;
				case "icon":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Icon = reader.GetString()!;
					break;
				case "role":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Role = reader.GetString()!;
					break;
				case "mobile":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Mobile = reader.GetInt32();
					break;
				case "payments":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Payments = reader.GetInt32();
					break;
				case "paymentsAll":
					message ??= new ResMessageDto();
					((ResMessageDto) message).PaymentsAll = JsonSerializer.Deserialize<Dictionary<string, int>>(
						ref reader,
						new JsonSerializerOptions(options)
						{
							NumberHandling = JsonNumberHandling.AllowReadingFromString
						})!;
					break;
				case "gg_plus_tier":
					message ??= new ResMessageDto();
					((ResMessageDto) message).GgPlusTier = reader.GetInt32();
					break;
				case "isStatus":
					message ??= new ResMessageDto();
					((ResMessageDto) message).IsStatus = reader.GetInt32();
					break;
				case "message_id":
					message ??= new ResMessageDto();
					((ResMessageDto) message).MessageId = reader.GetInt64();
					break;
				case "timestamp":
					message ??= new ResMessageDto();
					((ResMessageDto) message).Timestamp = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());
					break;
				case "regtime":
					message ??= new ResMessageDto();
					if (reader.TokenType != JsonTokenType.Null)
						((ResMessageDto) message).RegTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());

					break;
			}
		}

		throw new JsonException("Expected EndObject token");
	}

	public override void Write(Utf8JsonWriter writer, IChatMessage value, JsonSerializerOptions options)
	{
		var type = value.GetType();
		JsonSerializer.Serialize(writer, value, type, options);
	}
}