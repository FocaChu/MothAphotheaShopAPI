namespace MothAphotheaShopAPI
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllAsync();

        Task<Purchase?> GetByIdAsync(Guid id);

        Task<Purchase> CreateAsync(PurchaseDTO dto);

        Task<Purchase?> UpdateAsync(Guid id, PurchaseDTO dto);

        Task<bool> DeleteAsync(Guid id);
    }
}
