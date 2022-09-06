using Microsoft.EntityFrameworkCore;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Persistance;

namespace wms.Repositories;

public class UserRepository : IUserRepository
{
    private readonly  PersistanceContext _context;
 
    public UserRepository(PersistanceContext context)
    {
       _context = context; 
    }

    public async Task<User?> GetUserByEmail(string userEmail)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(user => user.Email == userEmail);

        return user;
    }

    public async Task AddDriver(Driver driver)
    {
        _context.Users.Add(driver);
        await _context.SaveChangesAsync();
    }

    public async Task AddWarehouseAdministrator(WarehouseAdministrator warehouseAdministrator)
    {
        _context.Users.Add(warehouseAdministrator);
        await _context.SaveChangesAsync();
    }

    public void DeleteDriver(int driverId)
    {
        throw new NotImplementedException();
    }

    public void DeleteWarehouseAdministrator(int warehouseAdministratorId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Driver>> GetAllDrivers()
    {
        var drivers = await _context.Users
            .Where(user => user.UserType == Enums.UserType.Driver)
            .ToListAsync();
        var drivers2 = drivers.Select(driver => driver.ToDriver()).ToList();
        return drivers2;
    }

    public async Task<List<WarehouseAdministrator>>  GetAllWarehouseAdministrators()
    {
        var wa = await _context.Users
            .Where(user => user.UserType == Enums.UserType.WarehouseAdministrator)
            .ToListAsync();
        var wa2 = wa.Select(wa => wa.ToWarehouseAdministrator()).ToList();
        return wa2;
    }
}