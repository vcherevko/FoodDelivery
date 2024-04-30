using FoodDelivery.Domain.ValueObjects;

namespace FoodDelivery.Domain.Entities;

public class Courier
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public required string Surname { get; set; }

	public required string Email { get; set; }

	public CourierStatus Status { get; set; }

	public string? Coordinates { get; set; }

	public required string PhoneNumber { get; set; }

	public bool IsDeleted { get; set; }

	public required ICollection<Order> Orders { get; set; }
}
