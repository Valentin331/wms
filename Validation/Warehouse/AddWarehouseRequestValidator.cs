using FluentValidation;
using wms.Contracts.Warehouse;

namespace wms.Validation.Warehouse;

public class AddWarehouseRequestValidator : AbstractValidator<AddWarehouseRequest>
{
  public AddWarehouseRequestValidator() 
    {
        RuleFor(x => x.Name).Length(4, 50);
        RuleFor(x => x.Capacity).InclusiveBetween(0,100);
    }
}