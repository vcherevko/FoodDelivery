using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

public interface IRestaurantRepository
{
	Task<IEnumerable<Order>> GetOrdersAsync(int restaurantId);

	Task<Restaurant?> GetRestaurantAsync(int restaurantId);

	Task<IList<RestaurantMenuItem>> GetAvailableMenuItemsAsync(int restaurantId, int[] menuItemIds);
}
