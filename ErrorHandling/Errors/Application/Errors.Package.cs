using ErrorOr;

namespace wms.ErrorHandling.Application;

public static partial class Errors
{
    public static class Package
    {
        public static Error PackageExists => Error.Conflict(code: "Package.AlreadyExists", description: "Package with that name already exists.");
        public static Error PackageNotFound => Error.Conflict(code: "Package.NotFound", description: "Package doesn't exist in the database.");
    }
}