using Inventory.IDAL;
using MongoDB.Driver;

namespace Inventory.DAL.Repositories;

public class DiagnosticsRepository(IMongoDatabase database)
	: IDiagnosticsRepository
{
	public Task<bool> IsDatabaseOnline()
	{
		return database.ListCollectionNames().AnyAsync();
	}
}