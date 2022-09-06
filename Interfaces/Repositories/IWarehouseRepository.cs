using wms.Entites;

namespace wms.Interfaces.Repositories;

public interface IWarehouseRepository
{
    // TODO: what should these methods return?
    Task AddWarehouse(Warehouse warehouse);
    Task<List<Warehouse>> GetAllWarehouses();
    Task DeleteWarehouse(int warehouseId);
    Task UpdateWarehouse(int warehouseId, Warehouse warehouse);
    Task<Warehouse?> GetWarehouseByName(string warehouseName);
    Task<Warehouse?> GetWarehouseById(int warehouseId);
}