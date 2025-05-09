using System.ComponentModel.DataAnnotations;

using Inventory.Interface.DTO.OrderLine;

namespace Inventory.Interface.DTO.OrderLine;

public class OrderLineDTO
{
    public ulong Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double VAT { get; set; }
    public string ModelId { get; set; }
}
