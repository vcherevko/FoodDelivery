using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface IRestaurantRepository
{
	Task<IEnumerable<Order>> GetOrdersAsync(int restaurantId, CancellationToken cancellationToken);

	Task<Restaurant?> GetRestaurantAsync(int restaurantId, CancellationToken cancellationToken);

	Task<IList<RestaurantMenuItem>> GetAvailableMenuItemsAsync(int restaurantId, int[] menuItemIds, CancellationToken cancellationToken);
}
