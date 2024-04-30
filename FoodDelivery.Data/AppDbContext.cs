using FoodDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options)
		: base(options)
	{
	}

	public DbSet<Consumer> Consumer { get; set; }

	public DbSet<Courier> Courier { get; set; }

	public DbSet<Order> Order { get; set; }

	public DbSet<OrderItem> OrderItem { get; set; }

	public DbSet<Restaurant> Restaurant { get; set; }

	public DbSet<RestaurantMenuItem> RestaurantMenuItem { get; set; }
}
