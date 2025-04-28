using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Inventory.Domain.Entities;
using Inventory.IBusiness;
using Inventory.IDAL;

namespace Inventory.Business;

public class BusinessLogicBase<T>(IRepository<T> repository)
	: IBusinessLogic<T> where T : IRootEntity
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

	public async Task Update(T entity)
	{
		await repository.EditAsync(entity);
	}

	public async Task Delete(T entity)
	{
		await repository.RemoveAsync(entity.Id!);
	}
}