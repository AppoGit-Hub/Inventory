using MongoDB.Driver;

using Inventory.Domain.Entities;
using Inventory.IDAL;
using Inventory.Shared.Interfaces;

namespace Inventory.DAL.Repositories;

public class OrderRepository(IMongoDatabase database, ITenantProvider tenantProvider)
    : RepositoryBase<Order>(database, tenantProvider), IOrderRepository;
