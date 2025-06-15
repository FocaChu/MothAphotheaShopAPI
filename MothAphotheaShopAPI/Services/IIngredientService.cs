namespace MothAphotheaShopAPI
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientViewDTO>> GetAllAsync();

        Task<IngredientViewDTO?> GetByIdAsync(int id);

        Task<Ingredient> CreateAsync(IngredientCreateDTO dto);

        Task<Ingredient?> UpdateAsync(int id, IngredientCreateDTO dto);

        Task<Ingredient?> UpdateSimpleAsync(int id, IngredientCreateDTO dto);

        Task<Ingredient?> UpdateActiveCompoundsAsync(int id, List<int> activeCompoundsIds);

        Task<Ingredient?> UpdateAromasAsync(int id, List<int> aromasIds);

        Task<Ingredient?> UpdateTexturesAsync(int id, List<int> texturesIds);

        Task<Ingredient?> UpdateEffectsAsync(int id, List<int> effectsIds);

        Task<Ingredient?> UpdateFlavorNotesAsync(int id, List<int> flavorNotesIds);

        Task<Ingredient?> UpdateContraindicationsAsync(int id, List<int> contraindicationsIds);

        Task<bool> DeleteAsync(int id);
    }
}
