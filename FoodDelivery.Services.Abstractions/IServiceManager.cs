namespace FoodDelivery.Services.Abstractions;

public interface IServiceManager
{
	IConsumerService ConsumerService { get; }

	ICourierService CourierService { get; }

	IRestaurantService RestaurantService { get; }
}
