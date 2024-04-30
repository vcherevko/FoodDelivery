namespace FoodDelivery.Domain.Exceptions;

public class OrderAccessDeniedException : FoodDeliveryAppException
{
	public OrderAccessDeniedException()
		: base("Order access denied.")
	{
	}

	public OrderAccessDeniedException(string message)
		: base(message)
	{
	}

	public OrderAccessDeniedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
