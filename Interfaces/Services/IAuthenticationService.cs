using ErrorOr;
using wms.Contracts;
using wms.Contracts.Authentication;
using wms.Contracts.Authentication.Login;
using wms.Contracts.Authentication.Register;
using wms.Entites;

namespace wms.Interfaces.Services;

public interface IAuthenticationService
{
    string GenerateJwtToken(User user);
    Task<ErrorOr<ServiceResponse<AuthResponse>>> RegisterUser(RegisterRequest request);
    Task<ErrorOr<ServiceResponse<AuthResponse>>> LoginUser(LoginRequest request);
}