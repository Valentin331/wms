using ErrorOr;
using wms.Contracts;
using wms.Contracts.Warehouse;
using wms.Entites;

namespace wms.Interfaces.Services;

public interface IWarehouseService
{
   public Task<ErrorOr<ServiceResponse<Warehouse>>> AddWarehouse(AddWarehouseRequest request);
   public Task<ErrorOr<ServiceResponse<List<Warehouse>>>> GetAllWarehouses();
   public Task<ErrorOr<ServiceResponse<Warehouse>>> DeleteWarehouse(int warehouseId);
   public Task<ErrorOr<ServiceResponse<Warehouse>>> UpdateWarehouse(int warehouseId, Warehouse warehouse);
}