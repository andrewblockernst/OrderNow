public interface IOrderService
{
    Task<Order> CreateOrderAsync(OrderDTO orderDto);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetAllOrdersAsync();
}