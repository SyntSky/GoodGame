namespace SyntSky.GoodGame.Api.Core.Interfaces;

public interface IApiService : IDisposable
{
	HttpClient HttpClient { get; }

	string BaseUri { get; }

	public IAuth? Auth { get; set; }

	string ApplicationName { get; }
}