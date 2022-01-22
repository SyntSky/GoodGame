using System.Collections.ObjectModel;
using SyntSky.GoodGame.Api.Core.Models;

namespace SyntSky.GoodGame.Api.Core.Interfaces;

public interface IApiServiceRequest<TResponse>
{
	string AdditionalPath { get; }

	HttpMethod Method { get; }
	ReadOnlyDictionary<string, Parameter> RequestParameters { get; }

	IApiService Service { get; }

	HttpRequestMessage CreateRequest();

	Task<TResponse> ExecuteAsync(CancellationToken cancellationToken = default);

	TResponse? Execute();

	Task<Stream> ExecuteAsStreamAsync(CancellationToken cancellationToken = default);

	Stream ExecuteAsStream();
}