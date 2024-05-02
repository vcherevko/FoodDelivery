using FoodDelivery.Contracts.Order;
using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Exceptions;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Domain.ValueObjects;
using FoodDelivery.Services.Abstractions;
using Mapster;

namespace FoodDelivery.Services;

public class ConsumerService : IConsumerService
{
	private readonly IRepositoryManager _repositoryManager;

	public ConsumerService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<OrderDto> GetOrderByIdAsync(int consumerId, int orderId, CancellationToken cancellationToken)
	{
		var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
		ValidateOrderAccess(order, consumerId);
		return order.Adapt<OrderDto>();
	}

	public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int consumerId, CancellationToken cancellationToken)
	{
		var orders = await _repositoryManager.ConsumerRepository.GetOrdersAsync(consumerId, cancellationToken);
		var adaptedOrders = orders.Adapt<IEnumerable<OrderDto>>().ToList();
		adaptedOrders.ForEach(o =>
		{
			o.TotalPrice = o.OrderItems.Sum(oi => oi.Price * oi.Quantity);
		});

		return adaptedOrders;
	}

	public async Task<int> CreateOrderAsync(int consumerId, OrderCreatingDto orderModel, CancellationToken cancellationToken)
	{
		var availableMenuItems = await ValidateOrderAsync(orderModel, cancellationToken);

		var order = orderModel.Adapt<Order>();
		foreach (var orderItem in order.OrderItems)
		{
			var menuItem = availableMenuItems.First(i => i.Id == orderItem.RestaurantMenuItemId);
			orderItem.Price = menuItem.Price;
		}

		order.ConsumerId = consumerId;
		order.Status = OrderStatus.ConsumerCreated;

		_repositoryManager.OrderRepository.Add(order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		return order.Id;
	}

	private async Task<IList<RestaurantMenuItem>> ValidateOrderAsync(OrderCreatingDto orderModel, CancellationToken cancellationToken)
	{
		var restaurant = await _repositoryManager.RestaurantRepository.GetRestaurantAsync(orderModel.RestaurantId, cancellationToken);
		if (restaurant is null)
		{
			throw new RestaurantIssueException($"Restaurant with id '{orderModel.RestaurantId}' doesn't exist.");
		}

		if (restaurant.Status != RestaurantStatus.Open)
		{
			throw new RestaurantIssueException($"Restaurant is {restaurant.Status.ToString()}.");
		}

		var menuItemIds = orderModel.OrderItems.Select(i => i.RestaurantMenuItemId).ToArray();
		var availableMenuItems = await _repositoryManager.RestaurantRepository.GetAvailableMenuItemsAsync(orderModel.RestaurantId, menuItemIds, cancellationToken);
		var availableMenuItemIds = availableMenuItems.Select(i => i.Id);
		var notAvailableMenuItemIds = menuItemIds.Except(availableMenuItemIds).ToArray();
		if (notAvailableMenuItemIds.Any())
		{
			throw new MenuItemsAvailabilityException($"Next menu items are not available. Menu item ids: {string.Join(", ", notAvailableMenuItemIds)}");
		}

		return availableMenuItems;
	}

	private static void ValidateOrderAccess(Order? order, int consumerId)
	{
		if (order is null)
		{
			throw new OrderNotFoundException();
		}

		if (order.ConsumerId == consumerId)
		{
			throw new OrderAccessDeniedException();
		}
	}
}
