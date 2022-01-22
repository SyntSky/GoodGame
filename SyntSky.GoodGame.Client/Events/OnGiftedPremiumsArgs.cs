using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnGiftedPremiumsArgs : EventArgs
{
	public OnGiftedPremiumsArgs(ResGiftedPremiumsDto data)
	{
		Data = data;
	}

	public ResGiftedPremiumsDto Data { get; init; }
}