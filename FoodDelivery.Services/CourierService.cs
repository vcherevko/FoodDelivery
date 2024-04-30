using FoodDelivery.Contracts.Delivery;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Services;

public class CourierService : ICourierService
{
	private readonly IRepositoryManager _repositoryManager;

	public CourierService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public Task<DeliveryDto> GetDeliveryAsync(int courierId, int deliveryId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<DeliveryDto>> GetAvailableDeliveriesAsync(int courierId)
	{
		throw new NotImplementedException();
	}

	public Task<bool> PickUpDeliveryAsync(int courierId, int deliveryId)
	{
		throw new NotImplementedException();
	}
}
