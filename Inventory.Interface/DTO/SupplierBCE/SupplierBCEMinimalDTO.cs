namespace Inventory.Interface.DTO.SupplierBCE;

public class SupplierBCEMinimalDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }

    //Contact
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    //Address
    public string? ZipCode { get; set; }
    public string? Municapility { get; set; }

    //Languages
    public List<string> Languages { get; set; }
}
