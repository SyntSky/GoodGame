using System.Text.Json.Serialization;
using SyntSky.GoodGame.Client.Converters;

namespace SyntSky.GoodGame.Client.Interfaces;

[JsonConverter(typeof(ChatMessageDtoJsonConverter))]
public interface IChatMessage : IChatDto
{
	public string Text { get; set; }
}