using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wms.Contracts.Package;
using wms.Interfaces.Services;
using ErrorOr;
using wms.Entites;

namespace wms.Controllers;

[AllowAnonymous]
[Route("package")]
public class PackageController : IController
{

    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
       _packageService = packageService; 
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddPackage(AddPackageRequest request)
    {
        // TODO: Consider creating a wrapper lambda expression to handle this easier
        var result = await _packageService.AddPackage(request); 

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllPackages()
    {
        var result = await _packageService.GetAllPackages();

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }
        
        return Ok(result.Value);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeletePackage(int packageId)
    {
        var result = await _packageService.DeletePackage(packageId);

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPut] 
    [Route("update")]
    public async Task<IActionResult> UpdatePackage(int packageId, Package package)
    {
        var result = await _packageService.UpdatePackage(packageId, package);

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }
}