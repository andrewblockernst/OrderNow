using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDto) {
        try
        {
            var order = await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }
}