namespace FoodDelivery.Domain.Exceptions;

public class FoodDeliveryAppException : Exception
{
	public FoodDeliveryAppException()
	{
	}

	public FoodDeliveryAppException(string message)
		: base(message)
	{
	}

	public FoodDeliveryAppException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
