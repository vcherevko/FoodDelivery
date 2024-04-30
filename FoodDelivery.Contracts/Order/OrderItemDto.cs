using FoodDelivery.Contracts.Restaurant;

namespace FoodDelivery.Contracts.Order;

public record OrderItemDto(double Price, int Quantity, RestaurantMenuItemDto RestaurantMenuItem);
