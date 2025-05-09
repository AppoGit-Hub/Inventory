namespace Inventory.Domain.Entities;

public class Mouvement
{
    public string InternalCode { get; set; }
    public DateTime Date { get; set; }
    public ulong Quantity { get; set; }
    public Mouvement Used { get; set; }
    public MouvementType Type { get; set; }
    public string? RecetteId { get; set; }
    private string? ProductId { get; set; }
    private string? BatchId { get; set; }
}
