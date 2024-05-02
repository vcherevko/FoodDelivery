using FoodDelivery.Contracts.Order;

namespace FoodDelivery.Services.Abstractions;

public interface IRestaurantService
{
	Task<OrderDto> GetOrderAsync(int restaurantId, int orderId, CancellationToken cancellationToken);

	Task<IEnumerable<OrderDto>> GetOrdersAsync(int restaurantId, CancellationToken cancellationToken);

	Task<bool> AcceptOrderAsync(int restaurantId, int orderId, CancellationToken cancellationToken);

	Task<bool> RejectOrderAsync(int restaurantId, int orderId, CancellationToken cancellationToken);

	Task<bool> CompleteOrderAsync(int restaurantId, int orderId, CancellationToken cancellationToken);
}
