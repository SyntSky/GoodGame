using SyntSky.GoodGame.Client.Dto.Chat;

namespace SyntSky.GoodGame.Client.Events;

public class OnDonateArgs : EventArgs
{
	public OnDonateArgs(ResPaymentDto paymentDto)
	{
		PaymentDto = paymentDto;
	}

	public ResPaymentDto PaymentDto { get; init; }
}