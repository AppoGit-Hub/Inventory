using System.ComponentModel.DataAnnotations;

using Inventory.Interface.DTO.OrderLine;

namespace Inventory.Interface.DTO.Order;

public class OrderUpdateDTO
{
    [Required]
    public string Id { get; set; }
    public int Version { get; set; }
    public string InternalCode { get; set; }
    public string ExternalCode { get; set; }
    public Nullable<DateTime> ShippingDate { get; set; }
    public Nullable<DateTime> IssueDate { get; set; }
    public Nullable<DateTime> PayLimitDate { get; set; }
    public string SupplierId { get; set; }
    public IEnumerable<OrderLineDTO> Lines { get; set; }
}
