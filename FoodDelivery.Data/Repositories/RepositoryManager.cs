using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Data.Repositories;

public class RepositoryManager : IRepositoryManager
{
	private readonly Lazy<IConsumerRepository> _lazyConsumerRepository;
	private readonly Lazy<ICourierRepository> _lazyCourierRepository;
	private readonly Lazy<IOrderRepository> _lazyOrderRepository;
	private readonly Lazy<IRestaurantRepository> _lazyRestaurantRepository;
	private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

	public RepositoryManager(AppDbContext dbContext)
	{
		_lazyConsumerRepository = new Lazy<IConsumerRepository>(() => new ConsumerRepository(dbContext));
		_lazyCourierRepository = new Lazy<ICourierRepository>(() => new CourierRepository(dbContext));
		_lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
		_lazyRestaurantRepository = new Lazy<IRestaurantRepository>(() => new RestaurantRepository(dbContext));
		_lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
	}

	public IConsumerRepository ConsumerRepository => _lazyConsumerRepository.Value;

	public ICourierRepository CourierRepository => _lazyCourierRepository.Value;

	public IOrderRepository OrderRepository => _lazyOrderRepository.Value;

	public IRestaurantRepository RestaurantRepository => _lazyRestaurantRepository.Value;

	public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}
