using ErrorOr;
using wms.Entites;

namespace wms;

public static class Utils
{
    public static Driver ToDriver(this User user)
    {
        return new Driver {
            Id = user.Id,
            UserType = user.UserType,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password
        };
    }

    public static WarehouseAdministrator ToWarehouseAdministrator(this User user)
        {
            return new WarehouseAdministrator {
                Id = user.Id,
                UserType = user.UserType,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }

    public static List<ErrorOr.Error> ConvertValidationErrorsToErrorOr(List<FluentValidation.Results.ValidationFailure> errors)
    {
        return errors
            .Select(validationFaliure => Error.Validation(validationFaliure.ErrorCode, validationFaliure.ErrorMessage))
            .ToList();
    }

}