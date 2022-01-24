using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Smiles;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Smiles
{
	private readonly IApiService _apiService;

	public Smiles(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetSmileRequest GetSmile()
	{
		return new GetSmileRequest(_apiService);
	}

	public sealed class GetSmileRequest : ApiServiceRequestBase<List<SmileDto>>
	{
		public GetSmileRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public override string AdditionalPath => "smiles";
		public override HttpMethod Method => HttpMethod.Get;
	}
}