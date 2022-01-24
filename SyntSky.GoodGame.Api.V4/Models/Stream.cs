using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Stream;
using SyntSky.GoodGame.Api.V4.Dto.Streams;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Stream
{
	private readonly IApiService _apiService;

	public Stream(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetChannelRequest GetChannel(string channelName)
	{
		return new GetChannelRequest(_apiService, channelName);
	}


	public virtual GetStreamsRequest GetStreams()
	{
		return new GetStreamsRequest(_apiService);
	}


	public virtual GetGamesRequest GetGames()
	{
		return new GetGamesRequest(_apiService);
	}

	public virtual GetGenresRequest GetGenres()
	{
		return new GetGenresRequest(_apiService);
	}

	public sealed class GetChannelRequest : ApiServiceRequestBase<ChannelDetailDto>
	{
		public GetChannelRequest(IApiService apiService, string channelName) : base(apiService)
		{
			InitParameters();
			ChannelName = channelName;
		}

		public string ChannelName
		{
			get => GetRequestParameter<string>("ChannelName");
			private init => SetRequestParameter("ChannelName", value);
		}

		public override string AdditionalPath => "stream";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("ChannelName", new Parameter
			{
				Name = "ChannelName",
				IsRequired = true,
				ParameterType = ParameterType.Path
			});
		}
	}

	public sealed class GetStreamsRequest : ApiServiceRequestBase<StreamDto>
	{
		public GetStreamsRequest(IApiService apiService) : base(apiService)
		{
			InitParameters();
		}

		public int Page
		{
			get => GetRequestParameter<int>("page");
			set => SetRequestParameter("page", value);
		}

		public int GgOnly
		{
			get => GetRequestParameter<int>("ggOnly");
			set => SetRequestParameter("ggOnly", value);
		}

		public string Game
		{
			get => GetRequestParameter<string>("game");
			set => SetRequestParameter("game", value);
		}

		public string Genre
		{
			get => GetRequestParameter<string>("genre");
			set => SetRequestParameter("genre", value);
		}

		public override string AdditionalPath => "stream";
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
			_requestParameters.Add("ggOnly", new Parameter
			{
				Name = "ggOnly",
				IsRequired = false,
				ParameterType = ParameterType.Query
			});
			_requestParameters.Add("game", new Parameter
			{
				Name = "game",
				IsRequired = false,
				ParameterType = ParameterType.Query
			});
			_requestParameters.Add("genre", new Parameter
			{
				Name = "genre",
				IsRequired = false,
				ParameterType = ParameterType.Query
			});
		}
	}

	public sealed class GetGamesRequest : ApiServiceRequestBase<GamesDto>
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

		public override string AdditionalPath => "stream/games";
		public override HttpMethod Method => HttpMethod.Get;

		protected override void InitParameters()
		{
			base.InitParameters();
			_requestParameters.Add("page", new Parameter
			{
				Name = "page",
				IsRequired = false,
				ParameterType = ParameterType.Query,
				DefaultValue = "1",
				Pattern = @"\d+"
			});
		}
	}

	public sealed class GetGenresRequest : ApiServiceRequestBase<GenresDto>
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

		public override string AdditionalPath => "stream/genres";
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