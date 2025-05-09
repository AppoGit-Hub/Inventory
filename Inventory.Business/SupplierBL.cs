using Inventory.Domain.Entities;
using Inventory.IBusiness;
using Inventory.IDAL;

namespace Inventory.Business;

public class SupplierBL(ISupplierRepository repository)
    : BusinessLogicBase<Supplier>(repository), ISupplierBL
{
    
}
