using Microsoft.Extensions.Configuration;

using Inventory.Shared.Interfaces;
using Inventory.Shared.Exceptions;

namespace Inventory.Shared.Implementations;

public class ConfigurationTenantProvider(IConfiguration configuration) : ITenantProvider
{
	private readonly string _tenantId = configuration["TenantId"] ?? throw new MissingTenantIdException();

	public string GetTenantId()
	{
		return _tenantId;
	}
}