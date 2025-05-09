namespace Inventory.Domain.Entities;

public class Order : IRootEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
    public string TenantId { get; set; }

    public string InternalCode { get; set; }
    public string? ExternalCode { get; set; }
    public DateTime? ShippingDate { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? PayLimitDate { get; set; }
    // Mise pour la génération de code des CRUDS 
    //public Supplier Supplier { get; set; }
    public string SupplierId { get; set; }
    public IEnumerable<OrderLine> Lines { get; set; }
}
