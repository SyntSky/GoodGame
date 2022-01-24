using SyntSky.GoodGame.Api.Core.Enums;

namespace SyntSky.GoodGame.Api.Core.Models;

public class Parameter
{
	public string Name { get; init; } = null!;
	public string? Pattern { get; init; }
	public bool IsRequired { get; init; }
	public object? Value { get; set; }
	public object? DefaultValue { get; init; }
	public ParameterType ParameterType { get; init; }
}