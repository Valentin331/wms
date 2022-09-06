using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wms.Contracts.Warehouse;
using wms.Interfaces.Services;
using ErrorOr;
using wms.Entites;

namespace wms.Controllers;

[AllowAnonymous]
[Route("warehouse")]
public class WarehouseController : IController
{

    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
       _warehouseService = warehouseService; 
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddWarehouse(AddWarehouseRequest request)
    {
        // TODO: Consider creating a wrapper lambda expression to handle this easier
        var result = await _warehouseService.AddWarehouse(request); 

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllWarehouses()
    {
        var result = await _warehouseService.GetAllWarehouses();

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }
        
        return Ok(result.Value);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteWarehouse(int warehouseId)
    {
        var result = await _warehouseService.DeleteWarehouse(warehouseId);

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPut] 
    [Route("update")]
    public async Task<IActionResult> UpdateWarehouse(int warehouseId, Warehouse warehouse)
    {
        var result = await _warehouseService.UpdateWarehouse(warehouseId, warehouse);

        if (result.IsError)
        {
            return ReturnErrors(result.Errors);
        }

        return Ok(result.Value);
    }
}