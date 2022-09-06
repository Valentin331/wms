using ErrorOr;

namespace wms.ErrorHandling.Application;

public static partial class Errors
{
    public static class Warehouse
    {
        public static Error WarehouseExists => Error.Conflict(code: "Warehouse.AlreadyExists", description: "Warehouse with that name already exists.");
        public static Error WarehouseNotFound => Error.Conflict(code: "Warehouse.NotFound", description: "Warehouse doesn't exist in the database.");
    }
}