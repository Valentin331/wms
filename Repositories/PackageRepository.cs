using Microsoft.EntityFrameworkCore;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Persistance;

namespace wms.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly PersistanceContext _context;

    public PackageRepository(PersistanceContext persistanceContext)
    {
       _context = persistanceContext; 
    }
    public async Task AddPackage(Package package)
    {
        _context.Packages.Add(package);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePackage(int packageId)
    {
       var package = await _context.Packages.FirstOrDefaultAsync(package => package.Id == packageId);

        // TODO: Figure error handling here asap!
        _context.Packages.Remove(package); 

        await _context.SaveChangesAsync();
    }

    public async Task<List<Package>> GetAllPackages()
    {
        var packages = await _context.Packages.ToListAsync();
        return packages;
    }

    public async Task<Package?> GetPackageById(int packageId)
    {
        var package = await _context.Packages
            .FirstOrDefaultAsync(package => package.Id == packageId);
        
        return package;
    }

    public async Task<Package?> GetPackageByName(string packageName)
    {
        var package = await _context.Packages
            .FirstOrDefaultAsync(package => package.Title == packageName);
        return package;
    }

    public async Task UpdatePackage(int packageId, Package package)
    {
        var packageDb = await _context.Packages.FirstOrDefaultAsync(package => package.Id == packageId);

        packageDb.Title = package.Title;
        packageDb.Value = package.Value;
        packageDb.Area = package.Area;
        packageDb.Deliveries = package.Deliveries;
        packageDb.StoredAtWarehouse = package.StoredAtWarehouse;
        packageDb.Weight = package.Weight;

        await _context.SaveChangesAsync();
    }
}