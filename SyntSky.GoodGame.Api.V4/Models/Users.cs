using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Users;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Users
{
	private readonly IApiService _apiService;

	public Users(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetUsersRequest GetUser(string nickName)
	{
		return new GetUsersRequest(_apiService, nickName);
	}

	public virtual GetUsersRequest GetUser(long id)
	{
		return new GetUsersRequest(_apiService, id.ToString());
	}

	public sealed class GetUsersRequest : ApiServiceRequestBase<UserDto>
	{
		public GetUsersRequest(IApiService apiService, string idOrNickName) : base(apiService)
		{
			InitParameters();
			IdOrNickName = idOrNickName;
		}

		public string IdOrNickName
		{
			get => GetRequestParameter<string>("idOrNickName");
			private init => SetRequestParameter("idOrNickName", value);
		}

		public override string AdditionalPath => "users";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("idOrNickName", new Parameter
			{
				Name = "id",
				IsRequired = true,
				ParameterType = ParameterType.Path
			});
		}
	}
}