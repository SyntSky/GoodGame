using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Login;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Login
{
	private readonly IApiService _apiService;

	public Login(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual PostLoginByPasswordRequest PostLoginByPassword(string username, string password)
	{
		return new PostLoginByPasswordRequest(_apiService, username, password);
	}

	public sealed class PostLoginByPasswordRequest : ApiServiceRequestBase<RootLoginByPassword>
	{
		public PostLoginByPasswordRequest(IApiService apiService, string username, string password) : base(apiService)
		{
			InitParameters();
			Password = password;
			Username = username;
		}

		public string Password
		{
			get => GetRequestParameter<string>("password");
			private init => SetRequestParameter("password", value);
		}

		public string Username
		{
			get => GetRequestParameter<string>("username");
			private init => SetRequestParameter("username", value);
		}

		public override string AdditionalPath => "login/password";
		public override HttpMethod Method => HttpMethod.Post;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("password", new Parameter
			{
				Name = "password",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("username", new Parameter
			{
				Name = "username",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
		}
	}
}