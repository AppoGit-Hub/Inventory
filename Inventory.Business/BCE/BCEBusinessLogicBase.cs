using Inventory.Domain.BCE;
using Inventory.IBusiness.BCE;
using Inventory.IDAL.BCE;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Inventory.Business.BCE;

public class BCEBusinessLogicBase<T>(IBCERepository<T> repository)
    : IBCEBusinessLogic<T> where T : IBCEEntity
{
    public async Task<DataSourceResult> Search(DataSourceRequest request)
    {
        return await repository
            .ReadAll()
            .ToDataSourceResultAsync(request);
    }

    public async Task<T?> GetById(string id)
    {
        return await repository.ReadAsync(id);
    }

    public async Task<T> Create(T entity)
    {
        return await repository.AddAsync(entity);
    }

    public async Task Delete(T entity)
    {
        await repository.RemoveAsync(entity.Id!);
    }
}