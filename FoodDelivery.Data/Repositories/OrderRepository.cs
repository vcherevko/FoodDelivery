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

	public async Task CreateAsync(Order order)
	{
		order.ChangedAt = DateTime.UtcNow;
		order.CreatedAt = DateTime.UtcNow;
		await _dbContext.Order.AddAsync(order);
	}

	public async Task<Order?> GetByIdAsync(int orderId)
	{
		return await _dbContext.Order.FirstOrDefaultAsync(o => o.Id == orderId);
	}
}
