namespace Inventory.Domain.BCE.CSV;

public class Denomination
{
    public string EntityNumber { get; set; }
    public LanguageType Language { get; set; }
    public DenominationType TypeOfDenomination { get; set; }
    public string Name { get; set; }
}