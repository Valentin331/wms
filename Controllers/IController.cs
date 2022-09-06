using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using wms.Contracts;
using wms.ErrorHandling;

namespace wms.Controllers;

[Authorize]
[ApiController]
public class IController : ControllerBase
{

   // TODO: Use only one function to return errors, remove distinction between one or more errors
   // TODO: Convert "errors" field to "remaning Errors" (or maybe just show all errors?) 

    protected IActionResult ReturnErrors(List<Error> errors)
    {
        // TODO: Implement 500 fallback error handling logic
        if (errors.Count is 0)
        {
            return Problem();
        } 

        if (errors.Count is 1)
        {
            return ReturnError(errors[0]);
        }

        // if (errors.All(error => error.Type == ErrorType.Validation))
        // {
        //     return ValidationError(errors);
        // }

        var serviceResponse = new ServiceResponse<MultiErrorResponse> {
            Success = false,
            Message = "ERROR",
            Data = new MultiErrorResponse {
                FirstError = errors[0],
                Errors = errors.Select(e => e.Code)
            }
        };

        return BadRequest(serviceResponse);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };  

        return Problem(statusCode: statusCode, title: error.Description);
    }

    // private IActionResult ReturnValidationErrors(List<Error> errors)
    // {

    // } 

    protected IActionResult ReturnError(ErrorOr.Error error) {
        var serviceResponse = new ServiceResponse<ErrorOr.Error> {
            Success = false,
            Message = "ERROR",
            Data = error
        };

        return BadRequest(serviceResponse);
    } 
}