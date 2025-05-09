using MongoDB.Driver;

using Inventory.Domain.BCE;
using Inventory.IDAL.BCE;

namespace Inventory.DAL.BCE;

public class SupplierBCERepository(IMongoDatabase database) 
    : BCERepositoryBase<SupplierBCE>(database), ISupplierBCERepository
{

}
