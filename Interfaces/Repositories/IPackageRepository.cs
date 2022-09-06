using wms.Entites;

namespace wms.Interfaces.Repositories;

public interface IPackageRepository
{
    // TODO: what should these methods return?
    Task AddPackage(Package package);
    Task<List<Package>> GetAllPackages();
    Task DeletePackage(int packageId);
    Task UpdatePackage(int packageId, Package package);
    Task<Package?> GetPackageByName(string packageName);
    Task<Package?> GetPackageById(int packageId);
}