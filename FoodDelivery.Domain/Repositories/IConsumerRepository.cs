using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface IConsumerRepository
{
	Task<IEnumerable<Order>> GetOrdersAsync(int consumerId, CancellationToken cancellationToken);
}
