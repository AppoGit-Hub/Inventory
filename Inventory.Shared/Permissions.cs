namespace Inventory.Shared;

public static class Permissions
{
    public const string ClaimType = "permissions";

	public static class Supplier
	{
		public const string READ = "read:supplier";
		public const string WRITE = "write:supplier";
	}

	public static class Order
	{
		public const string READ = "read:order";
		public const string WRITE = "write:order";
	}

	public static class Model
	{
		public const string READ = "read:model";
		public const string WRITE = "write:model";
	}
}
