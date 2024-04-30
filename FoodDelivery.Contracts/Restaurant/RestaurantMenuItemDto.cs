namespace FoodDelivery.Contracts.Restaurant;

public record RestaurantMenuItemDto(string Name, double Price, string? Description, string? ImagePath);
