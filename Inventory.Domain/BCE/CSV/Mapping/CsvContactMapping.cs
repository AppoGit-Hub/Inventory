using TinyCsvParser.Mapping;
using TinyCsvParser.Model;

namespace Inventory.Domain.BCE.CSV.Mapping;

public class CsvContactMapping : CsvMapping<Contact>
{
    public CsvContactMapping() : base()
    {
        MapProperty(0, x => x.EntityNumber);
        MapProperty(1, x => x.EntityContact);
        MapUsing((entity, values) =>
        {
            var contactRaw = values.Tokens[2];
            switch (contactRaw)
            {
                case "EMAIL":
                    entity.ContactType = ContactType.EMAIL;
                    break;
                case "TEL":
                    entity.ContactType = ContactType.TEL;
                    break;
                case "WEB":
                    entity.ContactType = ContactType.WEB;
                    break;
                case "FAX":
                    entity.ContactType = ContactType.FAX;
                    break;
                default:
                    return false;
            }

            return true;
        });
        MapProperty(3, x => x.Value);
    }
}
