namespace Inventory.Domain.Entities;

public class Model : IRootEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
    public string TenantId { get; set; }

    public string InternalCode { get; set; }
    public string? ExternalCode { get; set; }
    public string Name { get; set; }
    public int Conditionement { get; set; }
    public string Unit { get; set; }
    public ManagementType ManagementType { get; set; }
    public IEnumerable<string> Batches { get; set; }
}
