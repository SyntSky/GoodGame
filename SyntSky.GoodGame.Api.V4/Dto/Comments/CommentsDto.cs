using System.Text.Json.Serialization;
using SyntSky.GoodGame.Api.V4.Converters;

namespace SyntSky.GoodGame.Api.V4.Dto.Comments;

public class CommentsDto
{
	[JsonPropertyName("comments")]
	public List<CommentDto> Comments { get; set; } = null!;

	[JsonPropertyName("user")]
	[JsonConverter(typeof(CommentUserConverter))]
	public UserDto? User { get; set; }

	[JsonPropertyName("top")]
	public List<CommentDto> TopComments { get; set; } = null!;
}