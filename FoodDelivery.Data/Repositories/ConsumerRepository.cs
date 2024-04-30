using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.Repositories;

public class ConsumerRepository : IConsumerRepository
{
	private readonly AppDbContext _dbContext;

	public ConsumerRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Order>> GetOrdersAsync(int consumerId)
	{
		return await _dbContext.Order
			.AsNoTracking()
			.Where(o => o.ConsumerId == consumerId)
			.Include(o => o.OrderItems)
			.ThenInclude(orderItem => orderItem.RestaurantMenuItem)
			.Include(o => o.Restaurant)
			.ToListAsync();
	}
}
