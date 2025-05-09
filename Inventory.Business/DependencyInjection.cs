using Microsoft.Extensions.DependencyInjection;

using Inventory.IBusiness;
using Inventory.IBusiness.BCE;
using Inventory.Business.BCE;

namespace Inventory.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<IDiagnosticsBL, DiagnosticsBL>();
		services.AddScoped<ISupplierBL, SupplierBL>();
        services.AddScoped<IBCEBL, BCEBL>();
		services.AddScoped<IOrderBL, OrderBL>();
        return services;
    }
}
