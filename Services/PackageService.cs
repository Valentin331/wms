using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using wms.Contracts;
using wms.Contracts.Package;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Interfaces.Services;

namespace wms.Services;

public class PackageService : IPackageService
{
   private readonly IPackageRepository _packageRepository;
    private readonly IValidator<AddPackageRequest> _addPackageRequestValidator;

    public PackageService
    (
        IPackageRepository packageRepository,
        IValidator<AddPackageRequest> addPackageRequestValidator
    )
    {
       _packageRepository = packageRepository; 
       _addPackageRequestValidator = addPackageRequestValidator;
    }

    public async Task<ErrorOr<ServiceResponse<Package>>> AddPackage(AddPackageRequest request)
    {
        await Task.CompletedTask;

        var package = new Package
        {
            Title = request.Title,
            Weight = request.Weight,
            Area = request.Area,
            StoredAtWarehouse = request.StoredAtWarehouse,
            Deliveries = request.Deliveries
        };

        ValidationResult validationResult = await _addPackageRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return wms.Utils.ConvertValidationErrorsToErrorOr(validationResult.Errors);
        }

        if (await _packageRepository.GetPackageByName(request.Title) is not null)
        {
            return ErrorHandling.Application.Errors.Package.PackageExists;
        }

        await _packageRepository.AddPackage(package);

        var response = new ServiceResponse<Package> {};

        response.Data = package;

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<Package>>> DeletePackage(int packageId)
    {
        await Task.CompletedTask;

        // TODO: Input validation

        var package = await _packageRepository.GetPackageById(packageId);

        if (package is null)
        {
           return ErrorHandling.Application.Errors.Package.PackageNotFound;
        } 

        await _packageRepository.DeletePackage(package.Id);
        
        var response = new ServiceResponse<Package> {
            Data = package,
            Message = "Package deleted."
        };

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<List<Package>>>> GetAllPackages()
    {
        await Task.CompletedTask;

        // TODO: What if an error happens in the repository level? Is that covered?
        var packages = await _packageRepository.GetAllPackages();

        var response = new ServiceResponse<List<Package>> {
            Data = packages
        };

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<Package>>> UpdatePackage(int packageId, Package package)
    {
        await Task.CompletedTask;

        var packageDb = await _packageRepository.GetPackageById(packageId);

        if (packageDb is null)
        {
           return ErrorHandling.Application.Errors.Package.PackageNotFound;
        } 

        await _packageRepository.UpdatePackage(packageDb.Id, package);

        // TODO: Re-query the object
        
        var response = new ServiceResponse<Package> {
            Data = package,
            Message = "Package updated."
        };

        return response;
    } 
}