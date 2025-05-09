using System.ComponentModel.DataAnnotations;
using Inventory.Interface.DTO.Supplier;


namespace Inventory.Interface.DTO.Supplier;

public class SupplierCreationDTO
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Fax { get; set; }
    public string WebSite { get; set; }
    public string Road { get; set; }
    public string HouseNumber { get; set; }
    public string BoxNumber { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
}
