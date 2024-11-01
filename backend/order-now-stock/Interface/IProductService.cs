public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductDTO productDto);
    Task<bool> DeleteAsync(int id);
    Task<Product> UpdateAsync(int id, ProductDTO productDto);
    Task<bool> UpdateStockAsync(IEnumerable<ProductStockUpdateDTO> products);
}
