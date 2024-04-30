namespace FoodDelivery.Domain.Exceptions;

public class OrderNotFoundException : FoodDeliveryAppException
{
	public OrderNotFoundException()
		: base("Order not found.")
	{
	}

	public OrderNotFoundException(string message)
		: base(message)
	{
	}

	public OrderNotFoundException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
