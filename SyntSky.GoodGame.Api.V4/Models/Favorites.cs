using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Favorites;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Favorites
{
	private readonly IApiService _apiService;

	public Favorites(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetFavoritesRequest GetFavorites()
	{
		return new GetFavoritesRequest(_apiService);
	}


	public virtual PostSubscribeRequest PostSubscribe(int objType, string obj)
	{
		return new PostSubscribeRequest(_apiService, objType, obj);
	}

	public virtual PostSubscribeRequest PostSubscribe(long channelId)
	{
		return new PostSubscribeRequest(_apiService, 7, channelId.ToString());
	}


	public virtual PostUnsubscribeRequest PostUnsubscribe(int objType, string obj)
	{
		return new PostUnsubscribeRequest(_apiService, objType, obj);
	}

	public virtual PostUnsubscribeRequest PostUnsubscribe(long channelId)
	{
		return new PostUnsubscribeRequest(_apiService, 7, channelId.ToString());
	}

	public sealed class GetFavoritesRequest : ApiServiceRequestBase<List<StreamDto>>
	{
		public GetFavoritesRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public override string AdditionalPath => "favorites";
		public override HttpMethod Method => HttpMethod.Get;
	}

	public sealed class PostSubscribeRequest : ApiServiceRequestBase<RootSubscribeDto>
	{
		public PostSubscribeRequest(IApiService apiService, int objType, string obj) : base(apiService)
		{
			InitParameters();
			ObjType = objType;
			Obj = obj;
		}

		public int ObjType
		{
			get => GetRequestParameter<int>("obj_type");
			private init => SetRequestParameter("obj_type", value);
		}

		public string Obj
		{
			get => GetRequestParameter<string>("obj");
			private init => SetRequestParameter("obj", value);
		}


		public int GetEmail
		{
			get => GetRequestParameter<int>("get_email");
			set => SetRequestParameter("get_email", value);
		}

		public int GetAnons
		{
			get => GetRequestParameter<int>("get_anons");
			set => SetRequestParameter("get_anons", value);
		}

		public int GetVideos
		{
			get => GetRequestParameter<int>("get_videos");
			set => SetRequestParameter("get_videos", value);
		}

		public int GetPush
		{
			get => GetRequestParameter<int>("get_push");
			set => SetRequestParameter("get_push", value);
		}

		public override string AdditionalPath => "favorites/subscribe";
		public override HttpMethod Method => HttpMethod.Post;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("obj_type", new Parameter
			{
				Name = "obj_type",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("obj", new Parameter
			{
				Name = "obj",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("get_email", new Parameter
			{
				Name = "get_email",
				IsRequired = false,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("get_anons", new Parameter
			{
				Name = "get_anons",
				IsRequired = false,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("get_videos", new Parameter
			{
				Name = "get_videos",
				IsRequired = false,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("get_push", new Parameter
			{
				Name = "get_push",
				IsRequired = false,
				ParameterType = ParameterType.Field
			});
		}
	}

	public sealed class PostUnsubscribeRequest : ApiServiceRequestBase<object?>
	{
		public PostUnsubscribeRequest(IApiService apiService, int objType, string obj) : base(apiService)
		{
			InitParameters();
			ObjType = objType;
			Obj = obj;
		}

		public int ObjType
		{
			get => GetRequestParameter<int>("obj_type");
			private init => SetRequestParameter("obj_type", value);
		}

		public string Obj
		{
			get => GetRequestParameter<string>("obj");
			private init => SetRequestParameter("obj", value);
		}

		public override string AdditionalPath => "favorites/unsubscribe";
		public override HttpMethod Method => HttpMethod.Post;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("obj_type", new Parameter
			{
				Name = "obj_type",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
			_requestParameters.Add("obj", new Parameter
			{
				Name = "obj",
				IsRequired = true,
				ParameterType = ParameterType.Field
			});
		}
	}
}