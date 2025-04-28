namespace Inventory.IDAL.Exceptions;

public class EntityNotFoundException(string entityName, string entityId)
	: Exception($"Entity {entityName} with id {entityId} could not be found");
