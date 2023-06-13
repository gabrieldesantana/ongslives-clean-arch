using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task InsertPropAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
