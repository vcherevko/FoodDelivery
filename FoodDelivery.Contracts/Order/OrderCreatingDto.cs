namespace FoodDelivery.Contracts.Order;

public record OrderCreatingDto(int RestaurantId, IEnumerable<OrderItemCreatingDto> OrderItems);
