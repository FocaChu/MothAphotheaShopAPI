namespace MothAphotheaShopAPI
{
    public interface IGenericService<TEntity, TDto>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(Guid id);

        Task<TEntity> CreateAsync(TDto dto);

        Task<TEntity?> UpdateAsync(Guid id, TDto dto);

        Task<bool> DeleteAsync(Guid id);
    }

}
