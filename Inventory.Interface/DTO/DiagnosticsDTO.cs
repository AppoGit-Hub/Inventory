namespace Inventory.Interface.DTO;

public class DiagnosticsDTO
{
	public required string AssemblyVersion { get; set; }
	public required bool IsAuthenticated { get; set; }
	public required bool DatabaseOnline { get; set; }
}