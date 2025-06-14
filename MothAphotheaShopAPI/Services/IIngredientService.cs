namespace MothAphotheaShopAPI
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();

        Task<Ingredient?> GetByIdAsync(int id);

        Task<Ingredient> CreateAsync(IngredientDTO dto);

        Task<Ingredient?> UpdateAsync(int id, IngredientDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
