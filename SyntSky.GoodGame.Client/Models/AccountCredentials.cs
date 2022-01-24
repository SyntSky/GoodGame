namespace SyntSky.GoodGame.Client.Models;

public class AccountCredentials
{
	public AccountCredentials(uint userId, string token)
	{
		Token = token;
		UserId = userId;
	}

	public string Token { get; }

	public uint UserId { get; }

	public static AccountCredentials GuestCredentials()
	{
		return new AccountCredentials(0, string.Empty);
	}

	protected bool Equals(AccountCredentials other)
	{
		return Token == other.Token && UserId == other.UserId;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((AccountCredentials) obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Token, UserId);
	}
}