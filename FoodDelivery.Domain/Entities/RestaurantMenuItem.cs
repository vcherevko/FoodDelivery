namespace FoodDelivery.Domain.Entities;

public class RestaurantMenuItem
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public int RestaurantId { get; set; }

	public Restaurant Restaurant { get; set; }

	public double Price { get; set; }

	public string? Description { get; set; }

	public bool IsAvailable { get; set; }

	public string? ImagePath { get; set; }

	public ICollection<OrderItem> OrderItems { get; set; }

	public bool IsDeleted { get; set; }
}
