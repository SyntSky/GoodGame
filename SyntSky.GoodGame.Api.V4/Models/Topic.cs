using SyntSky.GoodGame.Api.Core.Enums;
using SyntSky.GoodGame.Api.Core.Interfaces;
using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Dto.Forum.Topic;

namespace SyntSky.GoodGame.Api.V4.Models;

public class Topic
{
	private readonly IApiService _apiService;

	public Topic(IApiService apiService)
	{
		_apiService = apiService;
	}

	public virtual GetTopicRequest GetTopic(long id)
	{
		return new GetTopicRequest(_apiService, id);
	}

	public sealed class GetTopicRequest : ApiServiceRequestBase<TopicDto>
	{
		public GetTopicRequest(IApiService apiService, long id) : base(apiService)
		{
			InitParameters();
			Id = id;
		}

		public long Id
		{
			get => GetRequestParameter<long>("id");
			private init => SetRequestParameter("id", value);
		}

		public override string AdditionalPath => "topic";
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