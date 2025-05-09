namespace Inventory.Domain.BCE.CSV;

public class Contact
{
    public string EntityNumber { get; set; }
    public string? EntityContact { get; set; }
    public ContactType ContactType { get; set; }
    public string? Value { get; set; }
}