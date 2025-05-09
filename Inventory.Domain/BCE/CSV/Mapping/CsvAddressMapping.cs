using TinyCsvParser.Mapping;

namespace Inventory.Domain.BCE.CSV.Mapping;

public class CsvAddressMapping : CsvMapping<Address>
{
    public CsvAddressMapping() : base()
    {
        MapProperty(0, x => x.EntityNumber);
        MapProperty(1, x => x.TypeOfAddress);
        MapProperty(2, x => x.CountryNL);
        MapProperty(3, x => x.CountryFR);
        MapProperty(4, x => x.ZipCode);
        MapProperty(5, x => x.MunicipalityNL);
        MapProperty(6, x => x.MunicipalityFR);
        MapProperty(7, x => x.StreetNL);
        MapProperty(8, x => x.StreetFR);
        MapProperty(9, x => x.HouseNumber);
        MapProperty(10, x => x.Box);
        MapProperty(11, x => x.ExtraAddressInfo);
        MapProperty(12, x => x.DateStrikingOff);
    }
}
