using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnPremiumArgs : EventArgs
{
	public OnPremiumArgs(ResPremiumDto premiumDto)
	{
		PremiumDto = premiumDto;
	}

	public ResPremiumDto PremiumDto { get; init; }
}