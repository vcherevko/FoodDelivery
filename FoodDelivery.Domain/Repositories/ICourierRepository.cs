using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface ICourierRepository
{
	Task<IEnumerable<Order>> GetMyDeliveriesAsync(int courierId, CancellationToken cancellationToken);

	Task<IEnumerable<Order>> GetNewDeliveriesAsync(CancellationToken cancellationToken);
}
