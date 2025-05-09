using MongoDB.Driver;

using Inventory.Domain.Entities;
using Inventory.IDAL;
using Inventory.Shared.Interfaces;

namespace Inventory.DAL.Repositories;

public class StockRepository(IMongoDatabase database, ITenantProvider tenantProvider)
    : RepositoryBase<Stock>(database, tenantProvider), IStockRepository;
