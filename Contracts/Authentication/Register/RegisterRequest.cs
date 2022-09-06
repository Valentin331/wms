using wms.Enums;

namespace wms.Contracts.Authentication.Register;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    UserType UserType
);