using System.Web;
using SyntSky.GoodGame.Api.Core.Interfaces;

namespace SyntSky.GoodGame.Api.Core.Models;

public class ApiTokenAuth : IAuth
{
	public ApiTokenAuth(string deviceId, string apiToken)
	{
		DeviceId = deviceId;
		ApiToken = apiToken;
	}

	public string ApiToken { get; init; }
	public string DeviceId { get; init; }

	public void AddAuthData(ref HttpRequestMessage httpRequestMessage)
	{
		var uriBuilder = new UriBuilder(httpRequestMessage.RequestUri!);

		var query = HttpUtility.ParseQueryString(uriBuilder.Query);
		query["api_token"] = ApiToken;
		query["device_id"] = DeviceId;
		uriBuilder.Query = query.ToString();

		httpRequestMessage.RequestUri = uriBuilder.Uri;
	}
}