using DomainModels.Models.Entities.Base;
using System.Linq.Expressions;

namespace Repository.RepositoryServices.Abstraction
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        ValueTask<T> FindByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(int id);
        bool Update(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> FindAllAsync
            (Expression<Func<T, bool>> predicate,
            IEnumerable<string> includingItems = null);
    }
}
