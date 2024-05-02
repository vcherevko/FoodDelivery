using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly AppDbContext _dbContext;

	public OrderRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public void Add(Order order)
	{
		order.ChangedAt = DateTime.UtcNow;
		order.CreatedAt = DateTime.UtcNow;
		_dbContext.Order.Add(order);
	}

	public async Task<Order?> GetByIdAsync(int orderId, CancellationToken cancellationToken)
	{
		return await _dbContext.Order.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
	}
}
