using FoodDelivery.Contracts.Order;
using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Exceptions;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Domain.ValueObjects;
using FoodDelivery.Services.Abstractions;
using Mapster;

namespace FoodDelivery.Services;

public class RestaurantService : IRestaurantService
{
	private readonly IRepositoryManager _repositoryManager;

	public RestaurantService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<OrderDto> GetOrderAsync(int restaurantId, int orderId)
	{
		var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId);
		ValidateOrderAccess(order, restaurantId);
		return order.Adapt<OrderDto>();
	}

	public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int restaurantId)
	{
		var orders = await _repositoryManager.RestaurantRepository.GetOrdersAsync(restaurantId);
		return orders.Adapt<IEnumerable<OrderDto>>();
	}

	public async Task<bool> AcceptOrderAsync(int restaurantId, int orderId)
	{
		return await ChangeOrderStatusAsync(restaurantId, orderId, OrderStatus.RestaurantAccepted);
	}

	public async Task<bool> RejectOrderAsync(int restaurantId, int orderId)
	{
		return await ChangeOrderStatusAsync(restaurantId, orderId, OrderStatus.RestaurantDenied);
	}

	public async Task<bool> CompleteOrderAsync(int restaurantId, int orderId)
	{
		return await ChangeOrderStatusAsync(restaurantId, orderId, OrderStatus.RestaurantCompleted);
	}

	private async Task<bool> ChangeOrderStatusAsync(int restaurantId, int orderId, OrderStatus status)
	{
		var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId);
		ValidateOrderAccess(order, restaurantId);

		order!.Status = status;
		return await _repositoryManager.UnitOfWork.SaveChangesAsync() > 0;
	}

	private static void ValidateOrderAccess(Order? order, int restaurantId)
	{
		if (order is null)
		{
			throw new OrderNotFoundException();
		}

		if (order.RestaurantId == restaurantId)
		{
			throw new OrderAccessDeniedException();
		}
	}
}
