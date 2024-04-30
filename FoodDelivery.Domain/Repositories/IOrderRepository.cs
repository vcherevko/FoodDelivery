using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface IOrderRepository
{
	Task CreateAsync(Order order);

	Task<Order?> GetByIdAsync(int orderId);
}
