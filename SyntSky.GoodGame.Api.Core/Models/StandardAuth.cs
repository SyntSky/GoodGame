using System.Net;
using System.Text;
using SyntSky.GoodGame.Api.Core.Interfaces;

namespace SyntSky.GoodGame.Api.Core.Models;

public class StandardAuth : IAuth
{
	public StandardAuth(Cookie idBad, Cookie tokenBad, Cookie uid)
	{
		IdBad = idBad;
		TokenBad = tokenBad;
		Uid = uid;
	}

	private Cookie IdBad { get; }
	private Cookie TokenBad { get; }
	private Cookie Uid { get; }

	public void AddAuthData(ref HttpRequestMessage httpRequestMessage)
	{
		httpRequestMessage.Headers.Add("cookie", $"{IdBad.ToString()}; {TokenBad.ToString()}; {Uid.ToString()}");
		// httpRequestMessage.Headers.Add("Set-Cookie", CookieToStr(IdBad));
		// httpRequestMessage.Headers.Add("Set-Cookie", CookieToStr(TokenBad));
		// httpRequestMessage.Headers.Add("Set-Cookie", CookieToStr(Uid));
	}

	private static string CookieToStr(Cookie cookie)
	{
		var stringBuilder =
			new StringBuilder($"{cookie.Name}={cookie.Value}; path={cookie.Path}; domain={cookie.Domain};");
		if (cookie.HttpOnly) stringBuilder.Append(" HttpOnly");

		return stringBuilder.ToString();
	}
}