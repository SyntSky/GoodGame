namespace SyntSky.GoodGame.Api.Core.Interfaces;

public interface IAuth
{
	void AddAuthData(ref HttpRequestMessage httpRequestMessage);
}