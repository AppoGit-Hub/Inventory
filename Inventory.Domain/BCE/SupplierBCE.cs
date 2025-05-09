using Inventory.Domain.BCE.CSV;

namespace Inventory.Domain.BCE;

public class SupplierNameLine
{
    public LanguageType Language { get; set; }
    public DenominationType Denomination { get; set; }
    public string Value { get; set; }

    public SupplierNameLine(LanguageType language, DenominationType denomination, string value)
    {
        Language = language;
        Denomination = denomination;
        Value = value;
    }
}
public abstract class GenericTranslationLine<T>
{
    public LanguageType Language { get; set; }
    public T Value { get; set; }

    public GenericTranslationLine(LanguageType language, T value)
    {
        Language = language;
        Value = value;
    }
}
public class SupplierTranslationLine : GenericTranslationLine<string?>
{
    public SupplierTranslationLine(LanguageType language, string? value) 
        : base(language, value)
    {

    }
}
public class SupplierBCE : IBCEEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }

    public string Number { get; set; }

    //Denomination
    public List<SupplierNameLine> NameTranslations { get; private set; } 
        = new List<SupplierNameLine>();

    //Contact
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Fax { get; set; }
    public string? WebSite { get; set; }

    //Address
    public string? HouseNumber { get; set; }
    public string? BoxNumber { get; set; }
    public string? ZipCode { get; set; }
    public List<SupplierTranslationLine> CountryTranslations { get; set; } 
        = new List<SupplierTranslationLine>();

    public List<SupplierTranslationLine> MunicipalityTranslations { get; set; }
        = new List<SupplierTranslationLine>();

    public List<SupplierTranslationLine> StreetTranslations { get; set; }
        = new List<SupplierTranslationLine>();
}