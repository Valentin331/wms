using wms.Entites;

namespace wms.Contracts.Authentication;

public record AuthResponse
(
    User user,
    string token
);