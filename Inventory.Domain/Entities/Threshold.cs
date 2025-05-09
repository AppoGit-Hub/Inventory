namespace Inventory.Domain.Entities;
public class Threshold
{
    public ulong Minimum { get; set; }
    public ulong Ideal { get; set; }
    public ulong Maximum { get; set; }
    public string ModelId {  get; set; }
}
