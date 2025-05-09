namespace Inventory.Domain.BCE.CSV;

public class Address
{
    public string EntityNumber { get; set; }
    public string? TypeOfAddress { get; set; }
    public string? CountryNL { get; set; }
    public string? CountryFR { get; set; }
    public string? ZipCode { get; set; }
    public string? MunicipalityNL { get; set; }
    public string? MunicipalityFR { get; set; }
    public string? StreetNL { get; set; }
    public string? StreetFR { get; set; }
    public string? HouseNumber { get; set; }
    public string? Box { get; set; }
    public string? ExtraAddressInfo { get; set; }
    public string? DateStrikingOff { get; set; }
}
