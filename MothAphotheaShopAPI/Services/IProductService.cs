namespace MothAphotheaShopAPI
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(ProductDTO dto);

        Task<Product?> UpdateAsync(int id, ProductDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
