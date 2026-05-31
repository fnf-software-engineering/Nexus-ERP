using OrderEngine.Domain.Interfaces.Generics;
using OrderEngine.Infrastructure.Data;

namespace OrderEngine.Infrastructure.Repositories.Generic;

/// <summary>
/// Generic repository responsible for write operations for the specified entity.
/// </summary>
public class WriteGenericRepository<T> : IWriteGenericRepository<T> where T : class
{
    protected readonly OrderEngineDbContext Context;
    
    // ReSharper disable once ConvertToPrimaryConstructor
    /// <summary>
    /// Initializes a new instance of the <see cref="WriteGenericRepository{T}"/> class.
    /// </summary>
    /// <param name="context">Database context used for persistence operations.</param>
    public WriteGenericRepository(OrderEngineDbContext context)
    {
        Context = context;
    }
    
    /// <summary>
    /// Adds a new entity to the context and persists the change to the database.
    /// </summary>
    /// <param name="entity">Entity to be added.</param>
    /// <param name="cancellationToken">Token used to cancel the asynchronous operation.</param>
    /// <returns>The added entity.</returns>
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Updates an existing entity and persists the change to the database.
    /// </summary>
    /// <param name="entity">Entity to be updated.</param>
    /// <param name="cancellationToken">Token used to cancel the asynchronous operation.</param>
    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Update(entity); 
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Removes an entity from the context and persists the change to the database.
    /// </summary>
    /// <param name="entity">Entity to be removed.</param>
    /// <param name="cancellationToken">Token used to cancel the asynchronous operation.</param>
    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}