using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Defines common repository methods for entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(TEntity entity);

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(TEntity entity);

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity, or null if not found.</returns>
    Task<TEntity?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all entities matching a given predicate.
    /// </summary>
    /// <param name="predicate">The predicate to filter entities.</param>
    /// <returns>A list of entities matching the predicate.</returns>
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
