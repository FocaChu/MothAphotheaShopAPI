namespace MothAphotheaShopAPI
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(Guid id);

        Task<Product> CreateAsync(ProductDTO dto);

        Task<Product?> UpdateAsync(Guid id, ProductDTO dto);

        Task<Product?> UpdateSimpleAsync(Guid id, ProductDTO dto);

        Task<Product?> UpdateAromasAsync(Guid id, List<Guid> aromaIds);

        Task<Product?> UpdateTexturesAsync(Guid id, List<Guid> texturesIds);

        Task<Product?> UpdateEffectsAsync(Guid id, List<Guid> effectsIds);

        Task<Product?> UpdateFlavorNotesAsync(Guid id, List<Guid> flavorNotesIds);

        Task<Product?> UpdateContraindicationsAsync(Guid id, List<Guid> contraindicationsIds);

        Task<bool> DeleteAsync(Guid id);
    }
}
