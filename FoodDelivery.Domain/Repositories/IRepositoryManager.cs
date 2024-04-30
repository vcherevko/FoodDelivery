namespace FoodDelivery.Domain.Repositories;

public interface IRepositoryManager
{
	IConsumerRepository ConsumerRepository { get; }

	ICourierRepository CourierRepository { get; }

	IRestaurantRepository RestaurantRepository { get; }

	IOrderRepository OrderRepository { get; }

	IUnitOfWork UnitOfWork { get; }
}
