using FoodDelivery.Contracts.Delivery;
using FoodDelivery.Contracts.Restaurant;

namespace FoodDelivery.Contracts.Order;

public class OrderDto
{
	public int Id { get; set; }

	public required RestaurantDto Restaurant { get; set; }

	public CourierDto? Courier { get; set; }

	public required string Status { get; set; }

	public DateTime CreatedAt { get; set; }

	public double TotalPrice { get; set; }

	public required ICollection<OrderItemDto> OrderItems { get; set; }
}
