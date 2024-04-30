namespace FoodDelivery.Domain.Exceptions;

public class MenuItemsAvailabilityException : FoodDeliveryAppException
{
	public MenuItemsAvailabilityException()
	{
	}

	public MenuItemsAvailabilityException(string message)
		: base(message)
	{
	}

	public MenuItemsAvailabilityException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
