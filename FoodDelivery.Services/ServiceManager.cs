using FoodDelivery.Domain.Repositories;
using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Services;

public class ServiceManager : IServiceManager
{
	private readonly Lazy<IConsumerService> _lazyConsumerService;
	private readonly Lazy<ICourierService> _lazyCourierService;
	private readonly Lazy<IRestaurantService> _lazyRestaurantService;

	public ServiceManager(IRepositoryManager repositoryManager)
	{
		_lazyConsumerService = new Lazy<IConsumerService>(() => new ConsumerService(repositoryManager));
		_lazyCourierService = new Lazy<ICourierService>(() => new CourierService(repositoryManager));
		_lazyRestaurantService = new Lazy<IRestaurantService>(() => new RestaurantService(repositoryManager));
	}

	public IConsumerService ConsumerService => _lazyConsumerService.Value;

	public ICourierService CourierService => _lazyCourierService.Value;

	public IRestaurantService RestaurantService => _lazyRestaurantService.Value;
}
