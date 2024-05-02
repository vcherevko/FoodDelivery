using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface IOrderRepository
{
	void Add(Order order);

	Task<Order?> GetByIdAsync(int orderId, CancellationToken cancellationToken);
}
