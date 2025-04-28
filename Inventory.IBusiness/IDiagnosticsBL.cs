namespace Inventory.IBusiness;

public interface IDiagnosticsBL
{
	public Task<bool> IsDatabaseOnlineAsync();
}