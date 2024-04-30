using FoodDelivery.Contracts.Order;

namespace FoodDelivery.Services.Abstractions;

public interface IConsumerService
{
	Task<OrderDto> GetOrderByIdAsync(int consumerId, int orderId);

	Task<IEnumerable<OrderDto>> GetOrdersAsync(int consumerId);

	Task<int> CreateOrderAsync(int consumerId, OrderCreatingDto order);
}
