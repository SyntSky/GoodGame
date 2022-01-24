using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.News;

namespace SyntSky.GoodGame.Api.V4.Models;

public class News
{
	private readonly IApiService _apiService;

	public News(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetNewsRequest GetNews()
	{
		return new GetNewsRequest(_apiService);
	}

	public virtual GetSpecificNewsRequest GetSpecificNews(long id)
	{
		return new GetSpecificNewsRequest(_apiService, id);
	}

	public sealed class GetNewsRequest : ApiServiceRequestBase<List<NewsBaseDto>>
	{
		public GetNewsRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public override string AdditionalPath => "news";
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

	public sealed class GetSpecificNewsRequest : ApiServiceRequestBase<NewsDetailDto>
	{
		public GetSpecificNewsRequest(IApiService apiService, long id) : base(apiService)
		{
			InitParameters();
			Id = id;
		}

		public long Id
		{
			get => GetRequestParameter<long>("id");
			private set => SetRequestParameter("id", value);
		}

		public override string AdditionalPath => "news";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("id", new Parameter
			{
				Name = "id",
				IsRequired = true,
				ParameterType = ParameterType.Path
			});
		}
	}
}