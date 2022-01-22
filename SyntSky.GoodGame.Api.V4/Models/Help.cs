using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Help;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Help
{
	private readonly IApiService _apiService;

	public Help(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetHelpRequest GetHelp()
	{
		return new GetHelpRequest(_apiService);
	}

	public virtual GetSectionRequest GetSection(int section)
	{
		return new GetSectionRequest(_apiService, section);
	}

	public virtual GetArticleRequest GetArticle(int article)
	{
		return new GetArticleRequest(_apiService, article);
	}

	public sealed class GetHelpRequest : ApiServiceRequestBase<List<SectionDto>>
	{
		public GetHelpRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public override string AdditionalPath => "help";
		public override HttpMethod Method => HttpMethod.Get;
	}

	public sealed class GetSectionRequest : ApiServiceRequestBase<SectionDto>
	{
		public GetSectionRequest(IApiService apiService, int section) : base(apiService)
		{
			InitParameters();
			Section = section;
		}

		public int Section
		{
			get => GetRequestParameter<int>("section");
			private init => SetRequestParameter("section", value);
		}

		public override string AdditionalPath => "help/section";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("section", new Parameter
			{
				Name = "section",
				IsRequired = true,
				ParameterType = ParameterType.Path
			});
		}
	}

	public sealed class GetArticleRequest : ApiServiceRequestBase<RootArticleDto>
	{
		public GetArticleRequest(IApiService apiService, int article) : base(apiService)
		{
			InitParameters();
			Article = article;
		}

		public int Article
		{
			get => GetRequestParameter<int>("article");
			private init => SetRequestParameter("article", value);
		}

		public override string AdditionalPath => "help/article";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("article", new Parameter
			{
				Name = "article",
				IsRequired = true,
				ParameterType = ParameterType.Path
			});
		}
	}
}