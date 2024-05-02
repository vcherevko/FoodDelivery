using FoodDelivery.Contracts.Delivery;

namespace FoodDelivery.Services.Abstractions;

public interface ICourierService
{
	Task<DeliveryDto> GetDeliveryAsync(int courierId, int deliveryId, CancellationToken cancellationToken);

	Task<IEnumerable<DeliveryDto>> GetAvailableDeliveriesAsync(int courierId, CancellationToken cancellationToken);

	Task<bool> PickUpDeliveryAsync(int courierId, int deliveryId, CancellationToken cancellationToken);
}
