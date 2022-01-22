using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Converters;
using SyntSky.GoodGame.Client.Interfaces;

namespace SyntSky.GoodGame.Client.Dto;

[JsonConverter(typeof(ChatDtoJsonConverter))]
public class ChatRootDto
{
	public ChatRootDto(string type, IChatDto data)
	{
		Type = type;
		Data = data;
	}

	[JsonPropertyName("type")]
	public string Type { get; init; }

	[JsonPropertyName("data")]
	public IChatDto Data { get; init; }
}