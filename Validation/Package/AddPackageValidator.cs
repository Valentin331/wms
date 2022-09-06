using FluentValidation;
using wms.Contracts.Package;

namespace wms.Validation.Package;

public class AddPackageRequestValidator : AbstractValidator<AddPackageRequest>
{
  public AddPackageRequestValidator() 
    {
        RuleFor(x => x.Title).Length(4, 50);
        RuleFor(x => x.Area).InclusiveBetween(0,100);
        RuleFor(x => x.Weight).InclusiveBetween(0,100);
        RuleFor(x => x.Value).InclusiveBetween(0,100);
    }
}