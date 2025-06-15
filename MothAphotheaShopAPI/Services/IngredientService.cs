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

        public async Task<IEnumerable<IngredientViewDTO>> GetAllAsync()
        {
            var ingredients = await _context.Ingredients
                .Include(i => i.Type)
                .Include(i => i.ActiveCompounds)
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorProfile)
                .Include(i => i.Effects)
                .Include(i => i.Contraindications)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IngredientViewDTO>>(ingredients);
        }


        public async Task<IngredientViewDTO?> GetByIdAsync(int id)
        {
            var ingredient = await _context.Ingredients
                .Include(i => i.Type)
                .Include(i => i.ActiveCompounds)
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorProfile)
                .Include(i => i.Effects)
                .Include(i => i.Contraindications)
                .FirstOrDefaultAsync(i => i.Id == id);

            return ingredient == null ? null : _mapper.Map<IngredientViewDTO>(ingredient);
        }


        public async Task<Ingredient> CreateAsync(IngredientCreateDTO dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);

            var type = await _context.IngredientTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Product type not found.");

            ingredient.Type = type;

            if (dto.ActiveCompoundsIds?.Any() == true)
                ingredient.ActiveCompounds = await GetAndValidateEntitiesAsync<ActiveCompound>(dto.ActiveCompoundsIds, "Active Compound");


            if (dto.AromasIds?.Any() == true)
                ingredient.Aromas = await GetAndValidateEntitiesAsync<Aroma>(dto.AromasIds, "Aroma");


            if (dto.TexturesIds?.Any() == true)
                ingredient.Textures = await GetAndValidateEntitiesAsync<Texture>(dto.TexturesIds, "Texture");


            if (dto.EffectsIds?.Any() == true)
                ingredient.Effects = await GetAndValidateEntitiesAsync<Effect>(dto.EffectsIds, "Effect");


            if (dto.FlavorsIds?.Any() == true)
                ingredient.FlavorProfile = await GetAndValidateEntitiesAsync<FlavorNote>(dto.FlavorsIds, "Flavor");


            if (dto.WarningsIds?.Any() == true)
                ingredient.Contraindications = await GetAndValidateEntitiesAsync<Contraindication>(dto.WarningsIds, "Contraindications");


            _context.Ingredients.Add(ingredient);

            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> UpdateAsync(int id, IngredientCreateDTO dto)
        {
            var existingIngredient = await _context.Ingredients.FindAsync(id);

            if (existingIngredient == null) return null;

            _mapper.Map(dto, existingIngredient);

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Product?> UpdateSimpleAsync(int id, IngredientCreateDTO dto)
        {
            var existingIngredient = await _context.Products
                .Include(p => p.Type) // Se Type for uma navegação
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var type = await _context.productTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Ingredient type not found.");

            _mapper.Map(dto, existingIngredient);
            existingIngredient.Type = type;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Product?> UpdateActiveCompoundsAsync(int id, List<int> activeCompoundsIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.ActiveCompounds)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var activeCompoundsList = await GetAndValidateEntitiesAsync<ActiveCompound>(activeCompoundsIds, "Active Compound");
            existingProduct.ActiveCompounds = activeCompoundsList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateAromasAsync(int id, List<int> aromasIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Aromas)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var aromasList = await GetAndValidateEntitiesAsync<Aroma>(aromasIds, "Aroma");
            existingProduct.Aromas = aromasList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateTexturesAsync(int id, List<int> texturesIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Textures)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var texturesList = await GetAndValidateEntitiesAsync<Texture>(texturesIds, "Texture");
            existingProduct.Textures = texturesList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateEffectsAsync(int id, List<int> effectsIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Effects)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var effectsList = await GetAndValidateEntitiesAsync<Effect>(effectsIds, "Effect");
            existingProduct.Effects = effectsList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateFlavorNotesAsync(int id, List<int> flavorNotesIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.FlavorNotes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var flavorsList = await GetAndValidateEntitiesAsync<FlavorNote>(flavorNotesIds, "Flavor");
            existingProduct.FlavorNotes = flavorsList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateContraindicationsAsync(int id, List<int> contraindicationsIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Contraindications)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var contraindicationsList = await GetAndValidateEntitiesAsync<Contraindication>(contraindicationsIds, "Contraindication");
            existingProduct.Contraindications = contraindicationsList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<List<T>> GetEntitiesByIdsAsync<T>(IEnumerable<int> ids) where T : class
        {
            var distinctIds = ids.Distinct();
            return await _context.Set<T>().Where(e => distinctIds.Contains(EF.Property<int>(e, "Id"))).ToListAsync();
        }

        private async Task<List<T>> GetAndValidateEntitiesAsync<T>(IEnumerable<int> ids, string entityName) where T : class
        {
            var entities = await GetEntitiesByIdsAsync<T>(ids);

            if (entities.Count != ids.Count())
                throw new BusinessException($"Some {entityName} not found.");

            return entities;
        }
    }
}
