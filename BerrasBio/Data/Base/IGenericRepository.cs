namespace BerrasBio.Data.Base
{
    //generic interface, so that all entities can use this for crud operations
    //I also added IEntityBase, which contains the id property which is used in all model classes
    public interface IGenericRepository<T> where T : class, IEntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task Delete(int id);
    }
}
