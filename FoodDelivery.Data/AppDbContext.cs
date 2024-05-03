using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.ValueObjects;
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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		SeedData(modelBuilder);
	}

	private void SeedData(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Restaurant>()
			.HasData(
				new Restaurant
				{
					Id = 1,
					Name = "Ukrainian Cuisine",
					Email = "ukrainiancuisine@gamil.com",
					Status = RestaurantStatus.Open,
					Address = "st. Second 1, Kiev",
					PhoneNumber = "+380773698741",
					Orders = new List<Order>(),
					MenuItems = new List<RestaurantMenuItem>()
				},
				new Restaurant
				{
					Id = 2,
					Name = "Sushi Star",
					Email = "sushistar@gamil.com",
					Status = RestaurantStatus.Open,
					Address = "st. Main 198, Kiev",
					PhoneNumber = "+380778899445",
					Orders = new List<Order>(),
					MenuItems = new List<RestaurantMenuItem>()
				},
				new Restaurant
				{
					Id = 3,
					Name = "HiTai",
					Email = "hitai@gamil.com",
					Status = RestaurantStatus.Closed,
					Address = "st. Narrow 33, Kiev",
					PhoneNumber = "+380777412369",
					Orders = new List<Order>(),
					MenuItems = new List<RestaurantMenuItem>()
				});

		modelBuilder.Entity<Courier>()
			.HasData(
				new Courier
				{
					Id = 1,
					Name = "Vasyl",
					Surname = "Savchuk",
					Email = "Vasya@gamil.com",
					PhoneNumber = "+380556988742",
					Orders = new List<Order>()
				},
				new Courier
				{
					Id = 2,
					Name = "Artem",
					Surname = "Bublik",
					Email = "Artem@gamil.com",
					PhoneNumber = "+380556985214",
					Orders = new List<Order>()
				});

		modelBuilder.Entity<Consumer>()
			.HasData(
				new Consumer
				{
					Id = 1,
					Name = "Tetiana",
					Surname = "Buchaka",
					Email = "tatiana@gamil.com",
					PhoneNumber = "+380556988797",
					Address = "st. Second 34, Kiev",
					Orders = new List<Order>()
				},
				new Consumer
				{
					Id = 2,
					Name = "Volodymyr",
					Surname = "Vovk",
					Email = "vladymyr@gamil.com",
					PhoneNumber = "+380667566448",
					Address = "st. Main 34, Kiev",
					Orders = new List<Order>()
				});

		modelBuilder.Entity<RestaurantMenuItem>()
			.HasData(
				new RestaurantMenuItem
				{
					Id = 1,
					Name = "Borch with cream",
					RestaurantId = 1,
					Price = 85.55,
					Description = "Ukrainian Traditional meal",
					IsAvailable = true
				},
				new RestaurantMenuItem
				{
					Id = 2,
					Name = "Vareniki",
					RestaurantId = 1,
					Price = 150,
					Description = "Original recipe",
					IsAvailable = true
				},
				new RestaurantMenuItem
				{
					Id = 3,
					Name = "Sushi with avocado",
					RestaurantId = 2,
					Price = 190,
					Description = "Original recipe from Japan",
					IsAvailable = true
				},
				new RestaurantMenuItem
				{
					Id = 4,
					Name = "Sushi California",
					RestaurantId = 2,
					Price = 230,
					Description = "Weight of set 500g.",
					IsAvailable = true
				},
				new RestaurantMenuItem
				{
					Id = 5,
					Name = "Soup with Red Hot Chili Pepper",
					RestaurantId = 3,
					Price = 350,
					Description = "Very hot and unforgettable",
					IsAvailable = true
				},
				new RestaurantMenuItem
				{
					Id = 6,
					Name = "Noodles with seafood",
					RestaurantId = 3,
					Price = 299.99,
					Description = "Very popular meal from Thailand",
					IsAvailable = true
				});
	}
}
