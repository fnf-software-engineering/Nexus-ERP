using System.Linq.Expressions;

namespace OrderEngine.Domain.Interfaces.Generics;

public interface IReadGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, 
        Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
    
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}