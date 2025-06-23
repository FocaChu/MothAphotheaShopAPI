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
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorNotes)
                .Include(i => i.Effects)
                .Include(i => i.Contraindications)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IngredientViewDTO>>(ingredients);
        }


        public async Task<IngredientViewDTO?> GetByIdAsync(Guid id)
        {
            var ingredient = await _context.Ingredients
                .Include(i => i.Type)
                .Include(i => i.Aromas)
                .Include(i => i.Textures)
                .Include(i => i.FlavorNotes)
                .Include(i => i.Effects)
                .Include(i => i.Contraindications)
                .FirstOrDefaultAsync(i => i.Id == id);

            return ingredient == null ? null : _mapper.Map<IngredientViewDTO>(ingredient);
        }


        public async Task<Ingredient> CreateAsync(IngredientInsertDTO dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);

            var type = await _context.IngredientTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Ingredient type not found.");

            ingredient.Type = type;


            if (dto.AromasIds?.Any() == true)
                ingredient.Aromas = await GetAndValidateEntitiesAsync<Aroma>(dto.AromasIds, "Aroma");


            if (dto.TexturesIds?.Any() == true)
                ingredient.Textures = await GetAndValidateEntitiesAsync<Texture>(dto.TexturesIds, "Texture");


            if (dto.EffectsIds?.Any() == true)
                ingredient.Effects = await GetAndValidateEntitiesAsync<Effect>(dto.EffectsIds, "Effect");


            if (dto.FlavorsIds?.Any() == true)
                ingredient.FlavorNotes = await GetAndValidateEntitiesAsync<FlavorNote>(dto.FlavorsIds, "Flavor");


            if (dto.ContraindicationingsIds?.Any() == true)
                ingredient.Contraindications = await GetAndValidateEntitiesAsync<Contraindication>(dto.ContraindicationingsIds, "Contraindications");


            _context.Ingredients.Add(ingredient);

            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> UpdateAsync(Guid id, IngredientInsertDTO dto)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Aromas)
                .Include(p => p.Textures)
                .Include(p => p.Effects)
                .Include(p => p.FlavorNotes)
                .Include(p => p.Contraindications)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var type = await _context.IngredientTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Ingredient type not found.");

            _mapper.Map(dto, existingIngredient);
            existingIngredient.Type = type;

            existingIngredient.Aromas = await GetAndValidateEntitiesAsync<Aroma>(dto.AromasIds, "Aroma");

            existingIngredient.Textures = await GetAndValidateEntitiesAsync<Texture>(dto.TexturesIds, "Texture");

            existingIngredient.Effects = await GetAndValidateEntitiesAsync<Effect>(dto.EffectsIds, "Effect");

            existingIngredient.Contraindications = await GetAndValidateEntitiesAsync<Contraindication>(dto.ContraindicationingsIds, "Contraindication");

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateSimpleAsync(Guid id, IngredientInsertDTO dto)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Type) 
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var type = await _context.IngredientTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Ingredient type not found.");

            _mapper.Map(dto, existingIngredient);
            existingIngredient.Type = type;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateAromasAsync(Guid id, List<Guid> aromasIds)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Aromas)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var aromasList = await GetAndValidateEntitiesAsync<Aroma>(aromasIds, "Aroma");
            existingIngredient.Aromas = aromasList;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateTexturesAsync(Guid id, List<Guid> texturesIds)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Textures)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var texturesList = await GetAndValidateEntitiesAsync<Texture>(texturesIds, "Texture");
            existingIngredient.Textures = texturesList;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateEffectsAsync(Guid id, List<Guid> effectsIds)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Effects)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var effectsList = await GetAndValidateEntitiesAsync<Effect>(effectsIds, "Effect");
            existingIngredient.Effects = effectsList;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateFlavorNotesAsync(Guid id, List<Guid> flavorNotesIds)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.FlavorNotes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var flavorsList = await GetAndValidateEntitiesAsync<FlavorNote>(flavorNotesIds, "Flavor");
            existingIngredient.FlavorNotes = flavorsList;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<Ingredient?> UpdateContraindicationsAsync(Guid id, List<Guid> contraindicationsIds)
        {
            var existingIngredient = await _context.Ingredients
                .Include(p => p.Contraindications)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingIngredient == null)
                return null;

            var contraindicationsList = await GetAndValidateEntitiesAsync<Contraindication>(contraindicationsIds, "Contraindication");
            existingIngredient.Contraindications = contraindicationsList;

            await _context.SaveChangesAsync();
            return existingIngredient;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<List<T>> GetEntitiesByIdsAsync<T>(IEnumerable<Guid> ids) where T : class
        {
            var distinctIds = ids.Distinct();
            return await _context.Set<T>().Where(e => distinctIds.Contains(EF.Property<Guid>(e, "Id"))).ToListAsync();
        }

        private async Task<List<T>> GetAndValidateEntitiesAsync<T>(IEnumerable<Guid> ids, string entityName) where T : class
        {
            var entities = await GetEntitiesByIdsAsync<T>(ids);

            if (entities.Count != ids.Count())
                throw new BusinessException($"Some {entityName} not found.");

            return entities;
        }
    }
}
