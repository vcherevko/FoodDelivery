using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
	private readonly AppDbContext _dbContext;

	public RestaurantRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Order>> GetOrdersAsync(int restaurantId, CancellationToken cancellationToken)
	{
		return await _dbContext.Order
					.Where(o => o.RestaurantId == restaurantId)
					.ToListAsync(cancellationToken);
	}

	public async Task<Restaurant?> GetRestaurantAsync(int restaurantId, CancellationToken cancellationToken)
	{
		return await _dbContext.Restaurant.SingleOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
	}

	public async Task<IList<RestaurantMenuItem>> GetAvailableMenuItemsAsync(int restaurantId, int[] menuItemIds, CancellationToken cancellationToken)
	{
		return await _dbContext.RestaurantMenuItem
			.AsNoTracking()
			.Where(mi => menuItemIds.Contains(mi.Id))
			.Where(mi => mi.RestaurantId == restaurantId)
			.Where(mi => mi.IsDeleted == false)
			.Where(mi => mi.IsAvailable == true)
			.Select(mi => new RestaurantMenuItem
			{
				Id = mi.Id,
				Name = mi.Name,
				Price = mi.Price
			})
			.ToArrayAsync(cancellationToken);
	}
}
