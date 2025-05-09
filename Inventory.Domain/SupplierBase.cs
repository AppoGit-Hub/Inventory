namespace Inventory.Domain;

public class SupplierBase
{
    public string Number { get; set; }
    
    //Denomination
    public string? Name { get; set; }

    //Contact
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Fax { get; set; }
    public string? WebSite { get; set; }

    //Address
    public string? Road { get; set; }
    public string? HouseNumber { get; set; }
    public string? BoxNumber { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
}
