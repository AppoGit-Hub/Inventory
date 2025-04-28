using MongoDB.Driver;

using Inventory.Domain.Entities;
using Inventory.IDAL;
using Inventory.IDAL.Exceptions;
using Inventory.Shared.Interfaces;

namespace Inventory.DAL.Repositories;

public class RepositoryBase<T>(IMongoDatabase database, ITenantProvider tenantProvider) : IRepository<T> where T : IRootEntity
{
    protected readonly IMongoCollection<T> _collection = database.GetCollection<T>(typeof(T).Name);
    
    protected readonly string _tenantId = tenantProvider.GetTenantId();
    
    public async virtual Task<T?> ReadAsync(string id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(document => document.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual IQueryable<T> ReadAll()
    {
        return _collection.AsQueryable().Where(document => document.TenantId == _tenantId);
    }

    public async virtual Task<T> EditAsync(T entity)
    {
        var data = await _collection.FindAsync(
            document => document.Id == entity.Id && document.TenantId == _tenantId
        );
        if (data is null)
        {
            throw new EntityNotFoundException(nameof(T), entity.Id!);
        }

        var combinedUpdate = Builders<T>.Update.Combine(
            typeof(T)
                .GetProperties()
                .Where(property =>
                    property.Name != "Id" && property.Name != "Version" && property.Name != "TenantId"
                )
                .Select(
                    property =>
                        Builders<T>
                            .Update.Set(
                                property.Name,
                                property.GetValue(entity)
                            )
                )
                .Append(Builders<T>.Update.Inc(document => document.Version, 1))
        );
        var updated = await _collection.UpdateOneAsync(
            document => document.Id == entity.Id && document.Version == entity.Version && document.TenantId == _tenantId,
            combinedUpdate
        );

        if (updated.ModifiedCount == 0)
        {
            throw new ConcurrentEditionDetectedException(nameof(T), entity.Id!);
        }

        return entity;
    }

    public async virtual Task<IEnumerable<T>> ReadAllAsync()
    {
        FilterDefinition<T>? filter = Builders<T>.Filter.Eq(document => document.TenantId, _tenantId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async virtual Task<T> AddAsync(T entity)
    {
        try
        {
            entity.TenantId = _tenantId;
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
        var res = await _collection.DeleteOneAsync(document => document.Id == id && document.TenantId == _tenantId);

        if (res.DeletedCount != 1)
        {
            throw new EntityNotFoundException(nameof(T), id);
        }
    }
}
