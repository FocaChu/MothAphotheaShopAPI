namespace MothAphotheaShopAPI
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(ProductDTO dto);

        Task<Product?> UpdateAsync(int id, ProductDTO dto);

        Task<Product?> UpdateSimpleAsync(int id, ProductDTO dto);

        Task<Product?> UpdateActiveCompoundsAsync(int id, List<int> activeCompoundsIds);

        Task<Product?> UpdateAromasAsync(int id, List<int> aromaIds);

        Task<Product?> UpdateTexturesAsync(int id, List<int> texturesIds);

        Task<Product?> UpdateEffectsAsync(int id, List<int> effectsIds);

        Task<Product?> UpdateFlavorNotesAsync(int id, List<int> flavorNotesIds);

        Task<Product?> UpdateContraindicationsAsync(int id, List<int> contraindicationsIds);

        Task<bool> DeleteAsync(int id);
    }
}
