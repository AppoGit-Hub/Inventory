using Kendo.Mvc.UI;

namespace Inventory.Interface.Extensions;

public class DataSourceResult<T> : DataSourceResult where T : class
{
    public new IEnumerable<T>? Data { get; set; }
}
