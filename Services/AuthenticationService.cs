using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wms.Contracts;
using wms.Contracts.Authentication;
using wms.Contracts.Authentication.Login;
using wms.Contracts.Authentication.Register;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Interfaces.Services;
using wms.Validation.User;

namespace wms.Services;

public class AuthenticationService : IAuthenticationService
{

    private readonly JwtSettings _jwtSettings;
    private readonly IValidator<RegisterRequest> _registerRequestValidator;
    private readonly IValidator<LoginRequest> _loginRequestValidator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService
    (
        IOptions<JwtSettings> jwtOptions,
        IUserRepository userRepository,
        IValidator<RegisterRequest> registerRequestValidator,
        IValidator<LoginRequest> loginRequestValidator
    )
    {
       _jwtSettings = jwtOptions.Value;
       _userRepository = userRepository;
       _registerRequestValidator = registerRequestValidator;
       _loginRequestValidator = loginRequestValidator;
    }

    public string GenerateJwtToken(User user)
    {
    var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public async Task<ErrorOr<ServiceResponse<AuthResponse>>> LoginUser(LoginRequest request)
    {
        await Task.CompletedTask;

        ValidationResult validationResult = await _loginRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return wms.Utils.ConvertValidationErrorsToErrorOr(validationResult.Errors);
        }

        var user = await _userRepository.GetUserByEmail(request.Email);

        if (user is null)
        {
            return ErrorHandling.Application.Errors.User.UserDoesntExist;
        }

        // TODO: Passwords should be hashed and then checked against that
        if (user.Password != request.Password)
        {
            return ErrorHandling.Application.Errors.User.InvalidCredentials;
        }

        var token = GenerateJwtToken(user);
        
        return new ServiceResponse<AuthResponse> {
            Data = new AuthResponse
            (
                user,
                token
            )
        };
    }

    public async Task<ErrorOr<ServiceResponse<AuthResponse>>> RegisterUser(RegisterRequest request)
    {
        await Task.CompletedTask;

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            UserType = request.UserType
        };

       ValidationResult validationResult = await _registerRequestValidator.ValidateAsync(request); 

        if (!validationResult.IsValid)
        {
            return wms.Utils.ConvertValidationErrorsToErrorOr(validationResult.Errors);
        }

        if (await _userRepository.GetUserByEmail(user.Email) is not null)
        {
            return ErrorHandling.Application.Errors.User.DuplicateEmail;
        }

        if (request.UserType == Enums.UserType.Driver)
        {
            await _userRepository.AddDriver((user.ToDriver()));
        }

        if (request.UserType == Enums.UserType.WarehouseAdministrator)
        {
            await _userRepository.AddWarehouseAdministrator((user.ToWarehouseAdministrator()));
        }

        var token = GenerateJwtToken(user);

        var serviceResponse = new ServiceResponse<AuthResponse> {};
        serviceResponse.Data = new AuthResponse
        (
           user,
           token 
        );

        return serviceResponse;
    }
}