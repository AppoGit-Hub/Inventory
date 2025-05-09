using Inventory.Domain.BCE;
using Inventory.IDAL.BCE;
using Inventory.IBusiness.BCE;

namespace Inventory.Business.BCE;

public class SupplierBCEBL(ISupplierBCERepository repository) 
    : BCEBusinessLogicBase<Supplier>(repository), ISupplierBCEBL
{

}
