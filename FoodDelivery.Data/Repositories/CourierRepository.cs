using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.Repositories;

public class CourierRepository : ICourierRepository
{
	private readonly AppDbContext _dbContext;

	public CourierRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Order>> GetMyDeliveriesAsync(int courierId, CancellationToken cancellationToken)
	{
		return await _dbContext.Order
					.Where(o => o.CourierId == courierId)
					.ToListAsync(cancellationToken);
	}

	public async Task<IEnumerable<Order>> GetNewDeliveriesAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.Order
					.Where(o => o.CourierId.HasValue == false)
					.ToListAsync(cancellationToken);
	}
}
