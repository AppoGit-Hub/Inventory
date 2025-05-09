namespace Inventory.Domain.BCE;

public interface IBCEEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
}
