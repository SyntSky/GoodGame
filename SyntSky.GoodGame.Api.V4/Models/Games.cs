using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Games;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Games
{
	private readonly IApiService _apiService;

	public Games(IApiService apiService)
	{
		_apiService = apiService;
	}


	public virtual GetGamesRequest GetGames()
	{
		return new GetGamesRequest(_apiService);
	}

	public sealed class GetGamesRequest : ApiServiceRequestBase<RootGamesDto>
	{
		public GetGamesRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public override string AdditionalPath => "games";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("page", new Parameter
			{
				Name = "page",
				IsRequired = false,
				ParameterType = ParameterType.Query
			});
		}
	}
}