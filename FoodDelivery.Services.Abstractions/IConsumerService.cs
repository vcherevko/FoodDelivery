using FoodDelivery.Contracts.Order;

namespace FoodDelivery.Services.Abstractions;

public interface IConsumerService
{
	Task<OrderDto> GetOrderByIdAsync(int consumerId, int orderId, CancellationToken cancellationToken);

	Task<IEnumerable<OrderDto>> GetOrdersAsync(int consumerId, CancellationToken cancellationToken);

	Task<int> CreateOrderAsync(int consumerId, OrderCreatingDto order, CancellationToken cancellationToken);
}
