using Inventory.Domain.Entities;

namespace Inventory.Domain.BCE;

public class Supplier : IBCEEntity
{
    public string Number { get; set; }
    public string Name { get; set; }

    //Contact
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Fax { get; set; }
    public string WebSite { get; set; }

    //Address
    public string Road { get; set; }
    public int HouseNumber { get; set; }
    public int BoxNumber { get; set; }
    public int MuniciaplityNumber { get; set; }
    public string Country { get; set; }

    //<Extra>
    public string? Id => this.Number;
    public int Version { get; set; }
}