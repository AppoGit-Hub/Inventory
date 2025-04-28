using Microsoft.Extensions.DependencyInjection;

using Inventory.IBusiness;

namespace Inventory.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<IDiagnosticsBL, DiagnosticsBL>();
        return services;
    }
}
