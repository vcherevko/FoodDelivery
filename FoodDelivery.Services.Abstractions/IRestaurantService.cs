using FoodDelivery.Contracts.Order;

namespace FoodDelivery.Services.Abstractions;

public interface IRestaurantService
{
	Task<OrderDto> GetOrderAsync(int restaurantId, int orderId);

	Task<IEnumerable<OrderDto>> GetOrdersAsync(int restaurantId);

	Task<bool> AcceptOrderAsync(int restaurantId, int orderId);

	Task<bool> RejectOrderAsync(int restaurantId, int orderId);

	Task<bool> CompleteOrderAsync(int restaurantId, int orderId);
}
