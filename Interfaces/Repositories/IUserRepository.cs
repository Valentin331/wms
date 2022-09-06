using wms.Entites;

namespace wms.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddWarehouseAdministrator(WarehouseAdministrator warehouseAdministrator);
    Task AddDriver(Driver driver);
    Task<List<WarehouseAdministrator>> GetAllWarehouseAdministrators();
    Task<List<Driver>> GetAllDrivers();
    void DeleteWarehouseAdministrator(int warehouseAdministratorId);
    void DeleteDriver(int driverId);
    Task<User?> GetUserByEmail(string userEmail);
}