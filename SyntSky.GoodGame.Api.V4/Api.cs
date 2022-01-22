using SyntSky.GoodGame.Api.Core.Models;
using SyntSky.GoodGame.Api.V4.Models;
using Stream = SyntSky.GoodGame.Api.V4.Models.Stream;

namespace SyntSky.GoodGame.Api.V4;

public class Api : BaseApiService
{
	public Api(Initializer initializer) : base(initializer)
	{
		Comments = new Comments(this);
		Favorites = new Favorites(this);
		Forum = new Forum(this);
		Games = new Games(this);
		Help = new Help(this);
		News = new News(this);
		Login = new Login(this);
		Smiles = new Smiles(this);
		Stream = new Stream(this);
		Streams = new Streams(this);
		Topic = new Topic(this);
		User = new User(this);
		Users = new Users(this);
	}

	public virtual Comments Comments { get; }
	public virtual Favorites Favorites { get; }
	public virtual Forum Forum { get; }
	public virtual Games Games { get; }
	public virtual Help Help { get; }
	public virtual Login Login { get; }
	public virtual News News { get; }
	public virtual Smiles Smiles { get; }
	public virtual Stream Stream { get; }
	public virtual Streams Streams { get; }
	public virtual Topic Topic { get; }
	public virtual User User { get; }
	public virtual Users Users { get; }

	public override string BaseUri => "https://goodgame.ru/api/4/";
}