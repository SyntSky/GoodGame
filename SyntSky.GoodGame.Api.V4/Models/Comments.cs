using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Comments;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Comments
{
	private readonly IApiService _apiService;

	public Comments(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetCommentsRequest GetComments(long id, int type = 11)
	{
		return new GetCommentsRequest(_apiService, id, type);
	}

	public sealed class GetCommentsRequest : ApiServiceRequestBase<CommentsDto>
	{
		public GetCommentsRequest(IApiService apiService, long id, int type) : base(apiService)
		{
			InitParameters();
			Id = id;
			Type = type;
		}

		public long Id
		{
			get => GetRequestParameter<long>("objId");
			private set => SetRequestParameter("objId", value);
		}

		public int Type
		{
			get => GetRequestParameter<int>("objType");
			private set => SetRequestParameter("objType", value);
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public override string AdditionalPath => "comments";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("objId", new Parameter
			{
				Name = "objId",
				IsRequired = true,
				ParameterType = ParameterType.Query
			});
			_requestParameters.Add("objType", new Parameter
			{
				Name = "objType",
				IsRequired = true,
				ParameterType = ParameterType.Query
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