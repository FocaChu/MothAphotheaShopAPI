namespace MothAphotheaShopAPI
{
    public interface IGenericService<TEntity, TDto>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TDto dto);

        Task<TEntity?> UpdateAsync(int id, TDto dto);

        Task<bool> DeleteAsync(int id);
    }

}
