using FoodDelivery.Domain.ValueObjects;

namespace FoodDelivery.Domain.Entities;

public class Restaurant
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public required string Email { get; set; }

	public RestaurantStatus Status { get; set; }

	public required string Address { get; set; }

	public required string PhoneNumber { get; set; }

	public bool IsDeleted { get; set; }

	public required ICollection<Order> Orders { get; set; }

	public required ICollection<RestaurantMenuItem> MenuItems { get; set; }
}
