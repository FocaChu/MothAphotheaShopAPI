namespace MothAphotheaShopAPI
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientViewDTO>> GetAllAsync();

        Task<IngredientViewDTO?> GetByIdAsync(Guid id);

        Task<Ingredient> CreateAsync(IngredientCreateDTO dto);

        Task<Ingredient?> UpdateAsync(Guid id, IngredientCreateDTO dto);

        Task<Ingredient?> UpdateSimpleAsync(Guid id, IngredientCreateDTO dto);

        Task<Ingredient?> UpdateActiveCompoundsAsync(Guid id, List<Guid> activeCompoundsIds);

        Task<Ingredient?> UpdateAromasAsync(Guid id, List<Guid> aromasIds);

        Task<Ingredient?> UpdateTexturesAsync(Guid id, List<Guid> texturesIds);

        Task<Ingredient?> UpdateEffectsAsync(Guid id, List<Guid> effectsIds);

        Task<Ingredient?> UpdateFlavorNotesAsync(Guid id, List<Guid> flavorNotesIds);

        Task<Ingredient?> UpdateContraindicationsAsync(Guid id, List<Guid> contraindicationsIds);

        Task<bool> DeleteAsync(Guid id);
    }
}
