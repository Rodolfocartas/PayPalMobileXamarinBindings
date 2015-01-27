using System;

namespace PayPalMobileXamarinBindings
{

	public enum PayPalShippingAddressOption : long /* nint */ {
		None = 0,
		Provided = 1,
		PayPal = 2,
		Both = 3
	}

	public enum PayPalPaymentIntent : long /* nint */ {
		Sale = 0,
		Authorize = 1,
		Order = 2
	}

	public enum PayPalPaymentViewControllerState : long /* nint */ {
		Unsent = 0,
		InProgress = 1
	}

}

