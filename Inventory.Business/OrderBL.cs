using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using Inventory.Domain.Entities;
using Inventory.IBusiness;
using Inventory.IDAL;

namespace Inventory.Business;

public class OrderBL(IOrderRepository repository) : BusinessLogicBase<Order>(repository), IOrderBL
{ }
