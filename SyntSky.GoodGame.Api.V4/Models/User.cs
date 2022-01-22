using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.User;

namespace SyntSky.GoodGame.Api.V4.Models;

public class User
{
	private readonly IApiService _apiService;

	public User(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetUserRequest GetUser(long id)
	{
		return new GetUserRequest(_apiService, id);
	}

	public virtual GetUserViewRequest GetUserView(long id)
	{
		return new GetUserViewRequest(_apiService, id);
	}

	public sealed class GetUserRequest : ApiServiceRequestBase<RootUserDto>
	{
		public GetUserRequest(IApiService apiService, long id) : base(apiService)
		{
			InitParameters();
			Id = id;
		}

		public long Id
		{
			get => GetRequestParameter<long>("id");
			private init => SetRequestParameter("id", value);
		}

		public override string AdditionalPath => "user";
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

	public sealed class GetUserViewRequest : ApiServiceRequestBase<RootViewDto>
	{
		public GetUserViewRequest(IApiService apiService, long id) : base(apiService)
		{
			InitParameters();
			Id = id;
		}

		public long Id
		{
			get => GetRequestParameter<long>("id");
			private init => SetRequestParameter("id", value);
		}

		public override string AdditionalPath => "user";
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

			_requestParameters.Add("view", new Parameter
			{
				Name = "view",
				IsRequired = true,
				ParameterType = ParameterType.Path,
				Value = "view"
			});
		}
	}
}