using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SyntSky.GoodGame.Api.Core.Interfaces;

namespace SyntSky.GoodGame.Api.Core.Models;

public abstract class BaseApiService : IApiService
{
	private readonly ILogger<BaseApiService> _logger;

	protected BaseApiService(Initializer initializer)
	{
		_logger = initializer.LoggerFactory?.CreateLogger<BaseApiService>() ?? NullLogger<BaseApiService>.Instance;
		ApplicationName = initializer.ApplicationName;
		HttpClient = CreateHttpClient(initializer);
	}

	public virtual void Dispose()
	{
		HttpClient.Dispose();
	}

	public HttpClient HttpClient { get; }
	public abstract string BaseUri { get; }
	public IAuth? Auth { get; set; } = new GuestAuth();
	public string ApplicationName { get; }

	private HttpClient CreateHttpClient(Initializer initializer)
	{
		var httpClient = initializer.HttpClientFactory.CreateClient();
		httpClient.DefaultRequestHeaders.Add("user-agent", ApplicationName);
		return httpClient;
	}

	public class Initializer
	{
		public Initializer(IHttpClientFactory httpClientFactory, string applicationName,
			ILoggerFactory? loggerFactory = null)
		{
			HttpClientFactory = httpClientFactory;
			ApplicationName = applicationName;
			LoggerFactory = loggerFactory;
		}

		public IHttpClientFactory HttpClientFactory { get; set; }
		public string ApplicationName { get; set; }
		public ILoggerFactory? LoggerFactory { get; set; }
	}
}