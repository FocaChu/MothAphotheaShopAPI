using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MothAphotheaShopAPI
{
    public class IngredientService : IIngredientService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public IngredientService(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorProfile)
                .Include(i => i.Effects)
                .Include(i => i.Warnings)
                .ToListAsync();
        }

        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            return await _context.Ingredients
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorProfile)
                .Include(i => i.Effects)
                .Include(i => i.Warnings)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Ingredient> CreateAsync(IngredientDTO dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);

            ingredient.Type = await _context.IngredientTypes.FindAsync(dto.TypeId);

            _context.Ingredients.Add(ingredient);

            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> UpdateAsync(int id, IngredientDTO dto)
        {
            var existingIngredient = await _context.Ingredients.FindAsync(id);

            if (existingIngredient == null) return null;

            _mapper.Map(dto, existingIngredient);

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
