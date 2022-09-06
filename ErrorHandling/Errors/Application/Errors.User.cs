using ErrorOr;

namespace wms.ErrorHandling.Application;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "User with that email already exists.");
        public static Error UserDoesntExist => Error.NotFound(code: "User.NotFound", description: "User does not exist.");
        public static Error InvalidCredentials => Error.Conflict(code: "User.InvalidCredentials", description: "Invalid credentials.");
    }
}