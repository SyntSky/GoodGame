using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;

namespace SyntSky.GoodGame.Api.Core.Models;

public abstract class ApiServiceRequestBase<TResponse> : IApiServiceRequest<TResponse>
{
	protected IDictionary<string, Parameter> _requestParameters = null!;

	protected ApiServiceRequestBase(IApiService service)
	{
		Service = service;
	}

	public IApiService Service { get; }
	public abstract string AdditionalPath { get; }
	public abstract HttpMethod Method { get; }
	public ReadOnlyDictionary<string, Parameter> RequestParameters => new(_requestParameters);

	public HttpRequestMessage CreateRequest()
	{
		var fieldParams = new Dictionary<string, string>();
		var uriBuilder = new UriBuilder(Service.BaseUri);
		uriBuilder.Path += AdditionalPath;

		var query = HttpUtility.ParseQueryString(uriBuilder.Query);

		foreach (var (_, parameter) in RequestParameters)
		{
			var value = parameter.Value?.ToString();
			if (string.IsNullOrEmpty(value))
			{
				value = parameter.DefaultValue?.ToString();
				if (string.IsNullOrEmpty(value))
				{
					if (parameter.IsRequired) throw new ArgumentNullException(parameter.Pattern);

					continue;
				}
			}

			switch (parameter.ParameterType)
			{
				case ParameterType.Path:
					uriBuilder.Path += @$"\{value}";
					break;
				case ParameterType.Query:
					query.Add(parameter.Name, value);
					break;
				case ParameterType.Field:
					fieldParams.Add(parameter.Name, value);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		if (query.Count != 0) uriBuilder.Query = query.ToString();

		var request = new HttpRequestMessage
		{
			RequestUri = uriBuilder.Uri,
			Method = Method
		};
		if (fieldParams.Count != 0) request.Content = JsonContent.Create(fieldParams);

		Service.Auth?.AddAuthData(ref request);
		return request;
	}

	public async Task<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
	{
		using var response2 = await ExecuteUnparsedAsync(cancellationToken);
		cancellationToken.ThrowIfCancellationRequested();
		return await JsonSerializer.DeserializeAsync<TResponse>(
			       await response2.Content.ReadAsStreamAsync(cancellationToken),
			       cancellationToken: cancellationToken) ??
		       throw new InvalidOperationException();
	}

	public TResponse Execute()
	{
		using var result = ExecuteUnparsedAsync(CancellationToken.None).Result;
		var readAsStringAsync = result.Content.ReadAsStringAsync().Result;
		return (JsonSerializer.Deserialize<TResponse>(result.Content.ReadAsStream()) ?? default)!;
	}

	public async Task<Stream> ExecuteAsStreamAsync(CancellationToken cancellationToken = default)
	{
		var httpResponseMessage = await ExecuteUnparsedAsync(cancellationToken);
		cancellationToken.ThrowIfCancellationRequested();
		return await httpResponseMessage.Content.ReadAsStreamAsync(CancellationToken.None);
	}

	public Stream ExecuteAsStream()
	{
		return ExecuteUnparsedAsync(CancellationToken.None).Result.Content.ReadAsStreamAsync().Result;
	}

	protected virtual void InitParameters()
	{
		_requestParameters = new Dictionary<string, Parameter>();
	}

	protected T GetRequestParameter<T>(string parameterName)
	{
		return (T) RequestParameters[parameterName].Value!;
	}

	protected void SetRequestParameter<T>(string parameterName, T value)
	{
		var requestParameter = RequestParameters[parameterName];
		if (string.IsNullOrEmpty(requestParameter.Pattern))
		{
			requestParameter.Value = value;
		}
		else
		{
			if (value == null) return;

			var match = Regex.Match(value.ToString()!, requestParameter.Pattern);
			if (!match.Success) throw new ArgumentException(parameterName);
			requestParameter.Value = match.Value;
		}
	}

	protected async Task<HttpResponseMessage> ExecuteUnparsedAsync(
		CancellationToken cancellationToken)
	{
		using var request = CreateRequest();
		var httpResponseMessage = await Service.HttpClient.SendAsync(request, cancellationToken);
		httpResponseMessage.EnsureSuccessStatusCode();
		return httpResponseMessage;
	}
}