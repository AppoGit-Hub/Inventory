using Kendo.Mvc.UI;

namespace Inventory.Interface.Extensions;

public static class DataSourceResultExt
{
    public static DataSourceResult<T> ToDataSourceResult<T>(this DataSourceResult result) where T : class
    {
        return new DataSourceResult<T>
        {
            Data = result.Data as IEnumerable<T>,
            Total = result.Total,
            AggregateResults = result.AggregateResults,
            Errors = result.Errors
        };
    }
}
