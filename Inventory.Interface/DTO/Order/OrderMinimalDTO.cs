using System.ComponentModel.DataAnnotations;


namespace Inventory.Interface.DTO.Order;

public class OrderMinimalDTO
{
    [Required]
    public string Id { get; set; }
    public string InternalCode { get; set; }
    public string ExternalCode { get; set; }
}
