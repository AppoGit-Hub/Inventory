namespace Inventory.Domain.Entities;

public class OrderLine
{
    public ulong Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double VAT { get; set; }
    public string ModelId { get; set; }
}
