using Microsoft.EntityFrameworkCore;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Persistance;

namespace wms.Repositories;

public class WarehouseRepository : IWarehouseRepository
{

    private readonly PersistanceContext _context;

    public WarehouseRepository(PersistanceContext persistanceContext)
    {
       _context = persistanceContext; 
    }

    public async Task AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWarehouse(int warehouseId)
    {
       var warehouse = await _context.Warehouses.FirstOrDefaultAsync(warehouse => warehouse.Id == warehouseId);

        // TODO: Figure error handling here asap!
        _context.Warehouses.Remove(warehouse); 

        await _context.SaveChangesAsync();
    }

    public async Task<List<Warehouse>> GetAllWarehouses()
    {
        var warehouses = await _context.Warehouses.ToListAsync();
        return warehouses;
    }

    public async Task<Warehouse?> GetWarehouseById(int warehouseId)
    {
        var warehouse = await _context.Warehouses
            .FirstOrDefaultAsync(warehouse => warehouse.Id == warehouseId);
        
        return warehouse;
    }

    public async Task<Warehouse?> GetWarehouseByName(string warehouseName)
    {
        var warehouse = await _context.Warehouses
            .FirstOrDefaultAsync(warehouse => warehouse.Name == warehouseName);
        return warehouse;
    }

    public async Task UpdateWarehouse(int warehouseId, Warehouse warehouse)
    {
        var warehouseDb = await _context.Warehouses.FirstOrDefaultAsync(warehouse => warehouse.Id == warehouseId);

        warehouseDb.Name = warehouse.Name;
        warehouseDb.Capacity = warehouse.Capacity;

        await _context.SaveChangesAsync();
    }
}