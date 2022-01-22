using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Streams;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Streams
{
	private readonly IApiService _apiService;

	public Streams(IApiService apiService)
	{
		_apiService = apiService;
	}


	public virtual GetGamesRequest GetGames()
	{
		return new GetGamesRequest(_apiService);
	}

	public virtual GetGenresRequest GetGenres()
	{
		return new GetGenresRequest(_apiService);
	}

	public sealed class GetGamesRequest : ApiServiceRequestBase<List<GameDto>>
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

		public override string AdditionalPath => "streams/games";
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

	public sealed class GetGenresRequest : ApiServiceRequestBase<List<GenreDto>>
	{
		public GetGenresRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public override string AdditionalPath => "streams/genres";
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