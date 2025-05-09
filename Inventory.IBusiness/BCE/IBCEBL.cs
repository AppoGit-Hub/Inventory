using Kendo.Mvc.UI;

namespace Inventory.IBusiness.BCE;

public interface IBCEBL
{
    Task<DataSourceResult> Search(DataSourceRequest request);
    void UnZip(string Filename);
}
