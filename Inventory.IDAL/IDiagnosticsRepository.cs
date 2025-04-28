namespace Inventory.IDAL;

public interface IDiagnosticsRepository
{
	public Task<bool> IsDatabaseOnline();
}