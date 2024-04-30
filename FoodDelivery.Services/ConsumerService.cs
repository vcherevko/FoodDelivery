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

	public async Task<OrderDto> GetOrderByIdAsync(int consumerId, int orderId)
	{
		var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId);
		ValidateOrderAccess(order, consumerId);
		return order.Adapt<OrderDto>();
	}

	public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int consumerId)
	{
		var orders = await _repositoryManager.ConsumerRepository.GetOrdersAsync(consumerId);
		var adaptedOrders = orders.Adapt<IEnumerable<OrderDto>>();
		var ordersAsync = adaptedOrders.ToList();
		ordersAsync.ForEach(o =>
		{
			o.TotalPrice = o.OrderItems.Sum(oi => oi.Price * oi.Quantity);
		});

		return ordersAsync;
	}

	public async Task<int> CreateOrderAsync(int consumerId, OrderCreatingDto orderModel)
	{
		var availableMenuItems = await ValidateOrderAsync(orderModel);

		var order = orderModel.Adapt<Order>();
		foreach (var orderItem in order.OrderItems)
		{
			var menuItem = availableMenuItems.First(i => i.Id == orderItem.RestaurantMenuItemId);
			orderItem.Price = menuItem.Price;
		}

		order.ConsumerId = consumerId;
		order.Status = OrderStatus.ConsumerCreated;

		await _repositoryManager.OrderRepository.CreateAsync(order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync();
		return order.Id;
	}

	private async Task<IList<RestaurantMenuItem>> ValidateOrderAsync(OrderCreatingDto orderModel)
	{
		var restaurant = await _repositoryManager.RestaurantRepository.GetRestaurantAsync(orderModel.RestaurantId);
		if (restaurant is null)
		{
			throw new RestaurantIssueException($"Restaurant with id '{orderModel.RestaurantId}' doesn't exist.");
		}

		if (restaurant.Status != RestaurantStatus.Open)
		{
			throw new RestaurantIssueException($"Restaurant is {restaurant.Status.ToString()}.");
		}

		var menuItemIds = orderModel.OrderItems.Select(i => i.RestaurantMenuItemId).ToArray();
		var availableMenuItems = await _repositoryManager.RestaurantRepository.GetAvailableMenuItemsAsync(orderModel.RestaurantId, menuItemIds);
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
