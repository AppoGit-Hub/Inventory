
using Inventory.Domain.BCE;
using Kendo.Mvc.UI;

namespace Inventory.IBusiness.BCE;
public interface IBCEBusinessLogic<T> where T : IBCEEntity
{
    Task<DataSourceResult> Search(DataSourceRequest request);
    Task<T?> GetById(string id);
    Task<T> Create(T entity);
}
