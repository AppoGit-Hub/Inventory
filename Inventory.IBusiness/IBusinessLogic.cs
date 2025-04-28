using Kendo.Mvc.UI;

using Inventory.Domain.Entities;

namespace Inventory.IBusiness;

public interface IBusinessLogic<T> where T : IRootEntity
{
	Task<DataSourceResult> Search(DataSourceRequest request);
	Task<T?> GetById(string id);
	Task<T> Create(T entity);
    Task Update(T entity);
	Task Delete(T entity);
}