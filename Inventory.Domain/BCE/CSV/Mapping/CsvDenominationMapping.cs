using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Inventory.Domain.BCE.CSV.Mapping;

public class CsvDenominationMapping : CsvMapping<Denomination>
{
    public CsvDenominationMapping() : base()
    {
        MapProperty(0, x => x.EntityNumber);
        MapProperty(1, x => x.Language, new EnumConverter<LanguageType>(true));
        MapProperty(2, x => x.TypeOfDenomination, new EnumConverter<DenominationType>(true));
        MapProperty(3, x => x.Name);
    }
}