using FoodDelivery.Domain.ValueObjects;

namespace FoodDelivery.Domain.Entities;

public class Order
{
	public int Id { get; set; }

	public int ConsumerId { get; set; }

	public Consumer Consumer { get; set; }

	public int RestaurantId { get; set; }

	public Restaurant Restaurant { get; set; }

	public int? CourierId { get; set; }

	public Courier? Courier { get; set; }

	public OrderStatus Status { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime ChangedAt { get; set; }

	public long Timestamp { get; set; }

	public required ICollection<OrderItem> OrderItems { get; set; }
}
