using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MothAphotheaShopAPI
{
    public class PurchaseService : IPurchaseService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public PurchaseService(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(Guid id)
        {
            return await _context.Purchases.FindAsync(id);
        }

        public async Task<Purchase> CreateAsync(PurchaseDTO dto)
        {
            var purchase = _mapper.Map<Purchase>(dto);

            if (dto.ProductIds?.Any() == true)
                purchase.Products = await GetAndValidateEntitiesAsync<Product>(dto.ProductIds, "Product");

            purchase.CalculateTotalAmount();

            _context.Purchases.Add(purchase);

            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase?> UpdateAsync(Guid id, PurchaseDTO dto)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null) return null;

            _mapper.Map(dto, purchase);

            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null) return false;

            _context.Purchases.Remove(purchase);

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
