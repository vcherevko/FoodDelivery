using FoodDelivery.Contracts.Order;
using FoodDelivery.Domain.Exceptions;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Consumer.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]/{consumerId}/order")]
public class ConsumerController : ControllerBase
{
	private readonly ILogger<ConsumerController> _logger;
	private readonly IConsumerService _consumerService;

	public ConsumerController(ILogger<ConsumerController> logger, IServiceManager consumerService)
	{
		_logger = logger;
		_consumerService = consumerService.ConsumerService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDto>))]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetAllAsync(int consumerId, CancellationToken cancellationToken)
	{
		try
		{
			return Ok(await _consumerService.GetOrdersAsync(consumerId, cancellationToken));
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpGet("{orderId:int}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByIdAsync(int consumerId, int orderId, CancellationToken cancellationToken)
	{
		try
		{
			return Ok(await _consumerService.GetOrderByIdAsync(consumerId, orderId, cancellationToken));
		}
		catch (OrderAccessDeniedException e)
		{
			return Forbid(e.Message);
		}
		catch (OrderNotFoundException e)
		{
			return NotFound(e.Message);
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> CreateOrderAsync(int consumerId, [FromBody]OrderCreatingDto orderModel, CancellationToken cancellationToken)
	{
		try
		{
			return Ok(await _consumerService.CreateOrderAsync(consumerId, orderModel, cancellationToken));
		}
		catch (FoodDeliveryAppException e)
		{
			return BadRequest(e.Message);
		}
		catch
		{
			return BadRequest();
		}
	}
}
