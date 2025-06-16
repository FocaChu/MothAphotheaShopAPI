using AutoMapper;
using AutoMapper.Features;
using Microsoft.EntityFrameworkCore;

namespace MothAphotheaShopAPI
{
    public class ProductService : IProductService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public ProductService(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Type)
                .Include(p => p.IngredientList)
                .Include(p => p.Aromas)
                .Include(p => p.Textures)
                .Include(p => p.Effects)
                .Include(p => p.FlavorNotes)
                .Include(p => p.Contraindications)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .Include(p => p.Type)
                .Include(p => p.IngredientList)
                .Include(p => p.Aromas)
                .Include(p => p.Textures)
                .Include(p => p.Effects)
                .Include(p => p.FlavorNotes)
                .Include(p => p.Contraindications)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateAsync(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);

            var type = await _context.ProductTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Product type not found.");


            product.Type = type;

            if (dto.IngridientsIds?.Any() == true)
                product.IngredientList = await GetAndValidateEntitiesAsync<Ingredient>(dto.IngridientsIds, "Ingredient");


            if (dto.ActiveCompoundsIds?.Any() == true)
                product.ActiveCompounds = await GetAndValidateEntitiesAsync<ActiveCompound>(dto.ActiveCompoundsIds, "Active Compound");


            if (dto.AromasIds?.Any() == true)
                product.Aromas = await GetAndValidateEntitiesAsync<Aroma>(dto.AromasIds, "Aroma");


            if (dto.TexturesIds?.Any() == true)
                product.Textures = await GetAndValidateEntitiesAsync<Texture>(dto.TexturesIds, "Texture");


            if (dto.EffectsIds?.Any() == true)
                product.Effects = await GetAndValidateEntitiesAsync<Effect>(dto.EffectsIds, "Effect");


            if (dto.FlavorsIds?.Any() == true)
                product.FlavorNotes = await GetAndValidateEntitiesAsync<FlavorNote>(dto.FlavorsIds, "Flavor");


            if (dto.ContraindicationsIds?.Any() == true)
                product.Contraindications = await GetAndValidateEntitiesAsync<Contraindication>(dto.ContraindicationsIds, "Contraindications");


            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(Guid id, ProductDTO dto)
        {
            var existingProduct = await _context.Products
                .Include(p => p.IngredientList)
                .Include(p => p.ActiveCompounds)
                .Include(p => p.Aromas)
                .Include(p => p.Textures)
                .Include(p => p.Effects)
                .Include(p => p.FlavorNotes)
                .Include(p => p.Contraindications)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var type = await _context.ProductTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Product type not found.");

            _mapper.Map(dto, existingProduct);
            existingProduct.Type = type;

            existingProduct.IngredientList = await GetAndValidateEntitiesAsync<Ingredient>(dto.IngridientsIds, "Ingredient");

            existingProduct.ActiveCompounds = await GetAndValidateEntitiesAsync<ActiveCompound>(dto.ActiveCompoundsIds, "Active Compound");

            existingProduct.Aromas = await GetAndValidateEntitiesAsync<Aroma>(dto.AromasIds, "Aroma");

            existingProduct.Textures = await GetAndValidateEntitiesAsync<Texture>(dto.TexturesIds, "Texture");

            existingProduct.Effects = await GetAndValidateEntitiesAsync<Effect>(dto.EffectsIds, "Effect");

            existingProduct.FlavorNotes = await GetAndValidateEntitiesAsync<FlavorNote>(dto.FlavorsIds, "Flavor");

            existingProduct.Contraindications = await GetAndValidateEntitiesAsync<Contraindication>(dto.ContraindicationsIds, "Contraindication");

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateSimpleAsync(Guid id, ProductDTO dto)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Type) // Se Type for uma navegação
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var type = await _context.ProductTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Product type not found.");

            _mapper.Map(dto, existingProduct);
            existingProduct.Type = type;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateIngredientsAsync(Guid id, List<Guid> ingredientsIds)
        {
            var existingProduct = await _context.Products
                .Include(p => p.IngredientList)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
                return null;

            var ingredientsList = await GetAndValidateEntitiesAsync<Ingredient>(ingredientsIds, "Ingredient");
            existingProduct.IngredientList = ingredientsList;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> UpdateActiveCompoundsAsync(Guid id, List<Guid> activeCompoundsIds)
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

        public async Task<Product?> UpdateAromasAsync(Guid id, List<Guid> aromasIds)
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

        public async Task<Product?> UpdateTexturesAsync(Guid id, List<Guid> texturesIds)
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

        public async Task<Product?> UpdateEffectsAsync(Guid id, List<Guid> effectsIds)
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

        public async Task<Product?> UpdateFlavorNotesAsync(Guid id, List<Guid> flavorNotesIds)
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

        public async Task<Product?> UpdateContraindicationsAsync(Guid id, List<Guid> contraindicationsIds)
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
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
