using MongoDB.Driver;

using Inventory.Domain.Entities;
using Inventory.IDAL;
using Inventory.Shared.Interfaces;

namespace Inventory.DAL.Repositories;

public class SupplierRepository(IMongoDatabase database, ITenantProvider tenantProvider)
    : RepositoryBase<Supplier>(database, tenantProvider), ISupplierRepository;
