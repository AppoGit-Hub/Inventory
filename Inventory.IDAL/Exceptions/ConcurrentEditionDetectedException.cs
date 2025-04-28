namespace Inventory.IDAL.Exceptions;

public class ConcurrentEditionDetectedException(string entityName, string entityId)
    : Exception($"Concurrent edition detected on entity {entityName}, id {entityId}");
