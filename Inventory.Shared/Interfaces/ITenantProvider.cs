namespace Inventory.Shared.Interfaces;

public interface ITenantProvider
{
	public string GetTenantId();
}