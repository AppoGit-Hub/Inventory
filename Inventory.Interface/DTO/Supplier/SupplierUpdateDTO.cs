using System.ComponentModel.DataAnnotations;


namespace Inventory.Interface.DTO.Supplier;

public class SupplierUpdateDTO
{
    [Required]
    public string Id { get; set; }
    public int Version { get; set; }
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
