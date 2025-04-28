using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Inventory.Shared.Implementations;
using Inventory.Shared.Interfaces;

namespace Inventory.Shared;

public static class DependencyInjection
{
	public static IServiceCollection AddShared(this IServiceCollection services)
	{
		services.AddSingleton<ITenantProvider, ConfigurationTenantProvider>();
		return services;
	}
}