using AutoMapper;
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

        public async Task<Product?> GetByIdAsync(int id)
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

            var type = await _context.productTypes.FindAsync(dto.TypeId);
            if (type == null)
                throw new BusinessException("Tipo de produto não encontrado.");

            product.Type = type;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product?> UpdateAsync(int id, ProductDTO dto)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null) return null;

            _mapper.Map(dto, existingProduct);

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
