using Microsoft.AspNetCore.Mvc;
using wms.Contracts.Authentication.Register;
using wms.Interfaces.Repositories;
using wms.Interfaces.Services;
using ErrorOr;
using wms.Contracts;
using wms.Entites;
using wms.Contracts.Authentication.Login;
using Microsoft.AspNetCore.Authorization;

namespace wms.Controllers;

[AllowAnonymous]
[Route("auth")]
public class AuthenticationController : IController
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController
    (
        IAuthenticationService authenticationService
    )
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authenticationService.RegisterUser(request);

        if (result.IsError)
        {
            // TODO: Maybe rename this to "handleErrors"?
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authenticationService.LoginUser(request);

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }
        
        return Ok(result.Value);
    }

}