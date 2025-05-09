using TinyCsvParser.Mapping;

namespace Inventory.Domain.BCE.CSV.Mapping;

public class CsvEntrepriseMapping : CsvMapping<Enterprise>
{
    public CsvEntrepriseMapping() : base()
    {
        MapProperty(0, x => x.EntrepriseNumber);
        MapProperty(1, x => x.Status);
        MapProperty(2, x => x.JuridicalSituation);
        MapProperty(3, x => x.TypeOfEntreprise);
        MapProperty(4, x => x.JuridicalForm);
        MapProperty(5, x => x.JuridicalFormCAC);
        MapProperty(6, x => x.StartDate);
    }
}
