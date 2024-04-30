using FoodDelivery.Contracts.Delivery;

namespace FoodDelivery.Services.Abstractions;

public interface ICourierService
{
	Task<DeliveryDto> GetDeliveryAsync(int courierId, int deliveryId);

	Task<IEnumerable<DeliveryDto>> GetAvailableDeliveriesAsync(int courierId);

	Task<bool> PickUpDeliveryAsync(int courierId, int deliveryId);
}
