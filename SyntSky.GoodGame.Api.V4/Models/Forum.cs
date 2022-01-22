using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Forum;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Forum
{
	private readonly IApiService _apiService;

	public Forum(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetForumRequest GetForum()
	{
		return new GetForumRequest(_apiService);
	}

	public virtual GetSubForumRequest GetSubForum(long id)
	{
		return new GetSubForumRequest(_apiService, id);
	}

	public sealed class GetForumRequest : ApiServiceRequestBase<ForumDto>
	{
		public GetForumRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public override string AdditionalPath => "forum";
		public override HttpMethod Method => HttpMethod.Get;
	}

	public sealed class GetSubForumRequest : ApiServiceRequestBase<ForumSectionTopicDetailDto>
	{
		public GetSubForumRequest(IApiService apiService, long id) : base(apiService)
		{
			InitParameters();
			Id = id;
		}

		public long Id
		{
			get => GetRequestParameter<long>("id");
			private set => SetRequestParameter("id", value);
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public override string AdditionalPath => "forum";
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
			_requestParameters.Add("page", new Parameter
			{
				Name = "page",
				IsRequired = false,
				ParameterType = ParameterType.Query
			});
		}
	}
}