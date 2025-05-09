#define PERF_TEST

using System.IO.Compression;
using System.Text;
using Inventory.Domain.BCE.CSV;
using Inventory.Domain.BCE.CSV.Mapping;
using Inventory.IBusiness.BCE;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using Inventory.Domain.BCE;
using Inventory.IDAL.BCE;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Diagnostics;

namespace Inventory.Business.BCE;

public class BCEBL(ISupplierBCERepository repository) : IBCEBL
{
    static string UNZIP_DIRECTORY = "unzip";
    static char DELIMITER = ',';
    static int THREADS = 8;

    public async Task<DataSourceResult> Search(DataSourceRequest request)
    {
        return await repository
            .ReadAll()
            .ToDataSourceResultAsync(request);
    }

    public async void UnZip(string Filename)
    {
        if (Directory.Exists(UNZIP_DIRECTORY))
        {
            Directory.Delete(UNZIP_DIRECTORY, true);
        }
        
        ZipFile.ExtractToDirectory(Filename, UNZIP_DIRECTORY);

        var options = new CsvParserOptions(true, DELIMITER, THREADS, true);
        Func<string, string> getFullPath = x => Path.Combine(UNZIP_DIRECTORY, x);

#if PERF_TEST
        Console.WriteLine($"Loading enterprise.csv");
#endif
        var enterprises = Extract<Enterprise, CsvEntrepriseMapping>(options, getFullPath("enterprise.csv"))
                            .Select(x => x.Result)
                            .ToList();
#if PERF_TEST
        Console.WriteLine($"Loading addresses.csv");
#endif
        var addresses = Extract<Address, CsvAddressMapping>(options, getFullPath("address.csv"))
                            .Select(x => x.Result)
                            .ToList();
#if PERF_TEST
        Console.WriteLine($"Loading contact.csv");
#endif
        var contacts = Extract<Contact, CsvContactMapping>(options, getFullPath("contact.csv"))
                            .Select(x => x.Result)
                            .ToList();
#if PERF_TEST
        Console.WriteLine($"Loading denominations.csv");
#endif
        var denominations = Extract<Denomination, CsvDenominationMapping>(options, getFullPath("denomination.csv"))
                            .Select(x => x.Result)
                            .ToList();

#if PERF_TEST
        Console.WriteLine($"To Dictionary...");
#endif
        var dictionnary = addresses.ToDictionary(adr => adr.EntityNumber);
        IList<SupplierBCE> suppliers = new List<SupplierBCE>();

#if PERF_TEST
        Console.WriteLine($"GO !");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
#endif

        int contacts_index = 0;
        int denomination_index = 0;
        int enterprises_index = 0;
        while (enterprises_index < enterprises.Count)
        {
            SupplierBCE supplier = new SupplierBCE();
            
            Enterprise entreprise = enterprises[enterprises_index];
            Func<string, int> entreCompar = each => String.Compare(each, entreprise.EntrepriseNumber);

            supplier.Number = entreprise.EntrepriseNumber;

            //Console.WriteLine(entreprise.EntrepriseNumber);

            //Address
            Address address;
            bool hasAddress = dictionnary.TryGetValue(entreprise.EntrepriseNumber, out address);
            if (hasAddress)
            {
                if (address.CountryFR != String.Empty && address.CountryFR != null)
                {
                    supplier.CountryTranslations.Add(new SupplierTranslationLine(LanguageType.FR, address.CountryFR));
                }

                if (address.CountryNL != String.Empty && address.CountryNL != null)
                {
                    supplier.CountryTranslations.Add(new SupplierTranslationLine(LanguageType.NL, address.CountryNL));
                }

                if (address.MunicipalityNL != String.Empty && address.MunicipalityNL != null)
                {
                    supplier.MunicipalityTranslations.Add(new SupplierTranslationLine(LanguageType.NL, address.MunicipalityNL));
                }

                if (address.MunicipalityFR != String.Empty && address.MunicipalityFR != null)
                {
                    supplier.MunicipalityTranslations.Add(new SupplierTranslationLine(LanguageType.FR, address.MunicipalityFR));
                }

                if (address.StreetNL != String.Empty && address.StreetNL != null)
                {
                    supplier.StreetTranslations.Add(new SupplierTranslationLine(LanguageType.NL, address.StreetNL));
                }

                if (address.StreetFR != String.Empty && address.StreetFR != null)
                {
                    supplier.StreetTranslations.Add(new SupplierTranslationLine(LanguageType.FR, address.StreetFR));
                }

                if (address.ZipCode != String.Empty && address.ZipCode != null)
                {
                    supplier.ZipCode = address.ZipCode;
                }

                if (address.HouseNumber != String.Empty && address.ZipCode != null)
                {
                    supplier.HouseNumber = address.HouseNumber;
                }

                if (address.Box != String.Empty && address.Box != null)
                {
                    supplier.BoxNumber = address.Box;
                }
            }

            //Contact
            while (contacts_index < contacts.Count && entreCompar(contacts[contacts_index].EntityNumber) == 0)
            {
                var contact = contacts[contacts_index];
                if (contact.ContactType == ContactType.EMAIL)
                {
                    supplier.Email = contact.Value;
                }
                else if (contact.ContactType == ContactType.TEL)
                {
                    supplier.PhoneNumber = contact.Value;
                }
                else if (contact.ContactType == ContactType.FAX)
                {
                    supplier.Fax = contact.Value;
                }
                else if (contact.ContactType == ContactType.WEB)
                {
                    supplier.WebSite = contact.Value;
                }

                contacts_index++;
            }

            //Denomination
            while (denomination_index < denominations.Count && entreCompar(denominations[denomination_index].EntityNumber) == 0)
            {
                var denomination = denominations[denomination_index];
                supplier.NameTranslations.Add(new SupplierNameLine(
                    denomination.Language,
                    denomination.TypeOfDenomination,
                    denomination.Name
                ));
                denomination_index++;
            }

            suppliers.Add(supplier);
            enterprises_index++;
        }

#if PERF_TEST
        Console.WriteLine($"Bulk add...");
#endif
        repository.AddManyAsync(suppliers);
#if PERF_TEST
        Console.WriteLine($"Finished !");
#endif
#if PERF_TEST
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
#endif
    }

    public IList<CsvMappingResult<ModelType>> Extract<ModelType, MapperType>(CsvParserOptions options, string filepath) 
        where ModelType : class, new()
        where MapperType : CsvMapping<ModelType>, new()
    {
        var mapper = new MapperType();
        var parser = new CsvParser<ModelType>(options, mapper);

        return parser
            .ReadFromFile(filepath, Encoding.UTF8)
            .ToList();
    }

    public int BinarySearch<T>(IList<T> list, Func<T, int> comparator)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = comparator(list[mid]);

            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}