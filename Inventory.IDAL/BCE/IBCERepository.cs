namespace Inventory.IDAL.BCE;
public interface IBCERepository<T>
{
    /// <summary>
    /// Asynchronously gets an entity from the database
    /// </summary>
    /// <param name="id">The entity's identifier</param>
    /// <returns>The entity</returns>
    Task<T?> ReadAsync(string id);

    /// <summary>
    /// Gets all entities from the database
    /// </summary>
    /// <returns>An enumeration of entities</returns>
    IQueryable<T> ReadAll();

    /// <summary>
    /// Asynchronously adds an entity in the database.
    /// </summary>
    /// <param name="entity">The entity to add</param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Asynchronously adds many entities in the database.
    /// </summary>
    /// <param name="entity">The entities to add</param>
    Task<IEnumerable<T>> AddManyAsync(IEnumerable<T> entities);

    /// <summary>
    /// Asynchronously removes an entity from the database.
    /// </summary>
    /// 
    /// <param name="id">The id of the entity to remove</param>
    /// <returns></returns>
    Task RemoveAsync(string id);
}

