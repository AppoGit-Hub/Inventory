using Inventory.IBusiness;
using Inventory.IDAL;

namespace Inventory.Business;

public class DiagnosticsBL(IDiagnosticsRepository repository): IDiagnosticsBL
{
	public async Task<bool> IsDatabaseOnlineAsync()
	{
		try
		{
			return await repository.IsDatabaseOnline();
		}
		catch (Exception)
		{
			return false;
		}
	}
}