using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly OrderContext _context;
    private readonly HttpClient _httpClient;

    public OrderService(OrderContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<Order> CreateOrderAsync(OrderDTO orderDto)
    {
        // Crear la orden
        var order = new Order
        {
            ProductIds = string.Join(",", orderDto.ProductIds),
            Quantities = string.Join(",", orderDto.Quantities),
        };

        // Añadir la orden a la base de datos
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Actualizar el stock de productos
        var productStockUpdates = orderDto.ProductIds
            .Select((productIds, index) => new ProductStockUpdateDTO
            {
                ProductIds = productIds,
                Quantity = orderDto.Quantities[index]
            });

        // Llamar al servicio de productos para actualizar el stock
        var response = await _httpClient.PutAsJsonAsync("http://localhost:5031/api/products/updateStockBatch", productStockUpdates);

        if (!response.IsSuccessStatusCode)
        {
            // Manejar el error si no se pudo actualizar el stock
            // Podrías deshacer la creación de la orden o tomar otra acción apropiada
            throw new Exception("No se pudo actualizar el stock de productos.");
        }

        return order;
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders.FindAsync(orderId);
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }
}
