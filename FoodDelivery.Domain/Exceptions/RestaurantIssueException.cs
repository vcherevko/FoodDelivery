namespace FoodDelivery.Domain.Exceptions;

public class RestaurantIssueException : FoodDeliveryAppException
{
	public RestaurantIssueException()
	{
	}

	public RestaurantIssueException(string message)
		: base(message)
	{
	}

	public RestaurantIssueException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
