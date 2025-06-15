namespace MothAphotheaShopAPI
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientViewDTO>> GetAllAsync();

        Task<IngredientViewDTO?> GetByIdAsync(int id);

        Task<Ingredient> CreateAsync(IngredientCreateDTO dto);

        Task<Ingredient?> UpdateAsync(int id, IngredientCreateDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
