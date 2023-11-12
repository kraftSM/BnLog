namespace BnLog.DAL.IRepository
{
    // <summary>
    /// Реализация UnitOfWork
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByGuidAsync(Guid guid);

        //Task<T?> GetByIdAsync(int id);
        //Task<Guid> CreateAsync(T item);
        Task<int> CreateAsync(T item);
        Task<int> UpdateAsync(T item);

        Task<int> DeleteAsync(T item);
    }
}
