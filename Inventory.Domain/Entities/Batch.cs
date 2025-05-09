namespace Inventory.Domain.Entities;

public class Batch
{
    public string InternalCode { get; set; }
    public string? ExternalCode { get; set; }
    public DateTime Date { get; set; }
    public ulong? Quantity { get; set; }
    public IEnumerable<string> Products { get; set; }
}