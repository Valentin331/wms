using FluentValidation;
using wms.Contracts.Authentication.Login;

namespace wms.Validation.Authentication.Login;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
  public LoginRequestValidator() 
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}