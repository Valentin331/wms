using FluentValidation;
using wms.Contracts.Authentication.Register;
using wms.Entites;
namespace wms.Validation.User;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator() 
    {
        RuleFor(x => x.UserType).IsInEnum();
        RuleFor(x => x.FirstName).Length(1, 30);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.LastName).Length(1, 30);
        RuleFor(x => x.Password).Length(4, 50);
    }
}