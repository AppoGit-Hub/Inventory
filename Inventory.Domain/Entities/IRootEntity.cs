namespace Inventory.Domain.Entities;

public interface IRootEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
    public string TenantId { get; set; }
}
