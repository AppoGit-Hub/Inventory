namespace Inventory.Domain.Entities;

public class Client : IRootEntity
{
    public string? Id { get; set; }
    public int Version { get; set ; }
    public string TenantId { get; set; }
}
