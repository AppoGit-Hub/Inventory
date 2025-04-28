namespace Inventory.Shared.Exceptions;

public class MissingTenantIdException()
	: Exception("Tenant ID is missing from configuration.");
