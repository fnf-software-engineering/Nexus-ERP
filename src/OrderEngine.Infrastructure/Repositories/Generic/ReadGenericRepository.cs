using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrderEngine.Domain.Interfaces.Generics;
using OrderEngine.Infrastructure.Data;

namespace OrderEngine.Infrastructure.Repositories.Generic;

/// <summary>
/// Generic repository responsible for read operations over EF Core entities.
/// </summary>
public class ReadGenericRepository<T> : IReadGenericRepository<T> where T : class
{
    
    protected readonly OrderEngineDbContext _context;
    protected readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new repository instance with the provided data context.
    /// </summary>
    /// <param name="context">Database context used for queries.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
    public ReadGenericRepository(OrderEngineDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    /// <summary>
    /// Gets an entity by its primary key value(s).
    /// </summary>
    /// <param name="keyValues">Primary key values.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The found entity, or <c>null</c> if it does not exist.</returns>
    public async Task<T?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(keyValues, cancellationToken);
    }

    /// <summary>
    /// Returns all entities from the table without tracking them in the context.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A sequence containing all found entities.</returns>
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Finds entities that match the specified predicate without tracking them in the context.
    /// </summary>
    /// <param name="predicate">Filter expression applied to the query.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A sequence containing the entities that satisfy the predicate.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        return await _dbSet.AsNoTracking() .Where(predicate) .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Returns a paginated set of entities, optionally filtered by a predicate.
    /// </summary>
    /// <param name="pageNumber">Requested page number (1-based).</param>
    /// <param name="pageSize">Number of records per page.</param>
    /// <param name="predicate">Optional filter applied before pagination.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A tuple containing the page items and the total number of records found.</returns>
    public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, 
        Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsNoTracking();
        if (predicate is not null)
            query = query.Where(predicate);
        
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return (items, totalCount);
    }

    /// <summary>
    /// Counts the number of records, optionally filtering by the specified criteria.
    /// </summary>
    /// <param name="predicate">Optional filter applied to the count.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The number of records found.</returns>
    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, 
        CancellationToken cancellationToken = default)
    {
        return predicate is null 
            ? await _dbSet.CountAsync(cancellationToken) 
            : await _dbSet.CountAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Checks whether at least one record matches the specified predicate.
    /// </summary>
    /// <param name="predicate">Filter expression applied to the check.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns><c>true</c> when at least one matching record exists; otherwise, <c>false</c>.</returns>
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }
}