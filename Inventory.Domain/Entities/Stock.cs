namespace Inventory.Domain.Entities;

public class Stock : IRootEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
    public string TenantId { get; set ; }

    public int Capacity { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Threshold> Thresholds { get; set; }
    public IEnumerable<Mouvement> Mouvements { get; set; }
    
    //Address
    public string? Road { get; set; }
    public string? HouseNumber { get; set; }
    public string? BoxNumber { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
}