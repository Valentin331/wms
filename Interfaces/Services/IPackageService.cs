using ErrorOr;
using wms.Contracts;
using wms.Contracts.Package;
using wms.Entites;

namespace wms.Interfaces.Services;

public interface IPackageService
{
   public Task<ErrorOr<ServiceResponse<Package>>> AddPackage(AddPackageRequest request);
   public Task<ErrorOr<ServiceResponse<List<Package>>>> GetAllPackages();
   public Task<ErrorOr<ServiceResponse<Package>>> DeletePackage(int packageId);
   public Task<ErrorOr<ServiceResponse<Package>>> UpdatePackage(int packageId, Package package);
}