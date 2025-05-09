using Inventory.Domain.Entities;
using Inventory.IDAL.Exceptions;
using Inventory.IDAL;
using Inventory.Shared.Interfaces;
using MongoDB.Driver;
using Inventory.Domain.BCE;
using Inventory.IDAL.BCE;
using MongoDB.Driver.Linq;

namespace Inventory.BCE.DAL;

public class BCERepositoryBase<T>(IMongoDatabase database)
    : IBCERepository<T> where T : IBCEEntity
{
    protected readonly IMongoCollection<T> _collection = database.GetCollection<T>(typeof(T).Name);

    public async virtual Task<T?> ReadAsync(string id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(document => document.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
    public virtual IQueryable<T> ReadAll()
    {
        return _collection.AsQueryable();
    }
    public async virtual Task<IEnumerable<T>> ReadAllAsync()
    {
        return await _collection.AsQueryable().ToListAsync();
    }
    public async virtual Task<T> AddAsync(T entity)
    {
        try
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while inserting new {typeof(T).Name} {entity.Id} : {ex.Message}");
        }
    }
    public async virtual Task RemoveAsync(string id)
    {
        var res = await _collection.DeleteOneAsync(document => document.Id == id);

        if (res.DeletedCount != 1)
        {
            throw new EntityNotFoundException(nameof(T), id);
        }
    }
}
