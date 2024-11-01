using Microsoft.EntityFrameworkCore;

public class ProductDbService : IProductService
{
    private readonly ProductContext _context;
    public ProductDbService(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Stock = productDto.Stock
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> UpdateAsync(int id, ProductDTO productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            await _context.SaveChangesAsync();
        }
        return product;
    }

    async Task<bool> IProductService.DeleteAsync(int id) {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateStockAsync(IEnumerable<ProductStockUpdateDTO> products)
    {
        foreach (var productUpdate in products)
        {
            // Obtener el producto desde la base de datos
            var product = await _context.Products.FindAsync(productUpdate.ProductIds);
            
            // Verificar si el producto existe
            if (product == null)
            {
                return false; // Producto no encontrado
            }

            // Verificar si hay suficiente stock
            if (product.Stock < productUpdate.Quantity)
            {
                return false; // Stock insuficiente
            }

            // Restar la cantidad del stock
            product.Stock -= productUpdate.Quantity;
            
            // Actualizar el producto en la base de datos
            _context.Products.Update(product);
        }

        // Guardar todos los cambios en una sola transacción
        await _context.SaveChangesAsync();
        
        return true; // Todo salió bien
    }
}
