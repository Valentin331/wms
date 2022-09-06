using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using wms.Contracts;
using wms.Contracts.Warehouse;
using wms.Entites;
using wms.Interfaces.Repositories;
using wms.Interfaces.Services;

namespace wms.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IValidator<AddWarehouseRequest> _addWarehouseRequestValidator;

    public WarehouseService
    (
        IWarehouseRepository warehouseRepository,
        IValidator<AddWarehouseRequest> addWarehouseRequestValidator
    )
    {
       _warehouseRepository = warehouseRepository; 
       _addWarehouseRequestValidator = addWarehouseRequestValidator;
    }

    public async Task<ErrorOr<ServiceResponse<Warehouse>>> AddWarehouse(AddWarehouseRequest request)
    {
        await Task.CompletedTask;

        var warehouse = new Warehouse
        {
           Name = request.Name,
           Capacity = request.Capacity 
        };

        ValidationResult validationResult = await _addWarehouseRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return wms.Utils.ConvertValidationErrorsToErrorOr(validationResult.Errors);
        }

        if (await _warehouseRepository.GetWarehouseByName(request.Name) is not null)
        {
            return ErrorHandling.Application.Errors.Warehouse.WarehouseExists;
        }

        await _warehouseRepository.AddWarehouse(warehouse);

        var response = new ServiceResponse<Warehouse> {};

        response.Data = warehouse;

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<Warehouse>>> DeleteWarehouse(int warehouseId)
    {
        await Task.CompletedTask;

        // TODO: Input validation

        var warehouse = await _warehouseRepository.GetWarehouseById(warehouseId);

        if (warehouse is null)
        {
           return ErrorHandling.Application.Errors.Warehouse.WarehouseNotFound;
        } 

        await _warehouseRepository.DeleteWarehouse(warehouse.Id);
        
        var response = new ServiceResponse<Warehouse> {
            Data = warehouse,
            Message = "Warehouse deleted."
        };

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<List<Warehouse>>>> GetAllWarehouses()
    {
        await Task.CompletedTask;

        // TODO: What if an error happens in the repository level? Is that covered?
        var warehouses = await _warehouseRepository.GetAllWarehouses();

        var response = new ServiceResponse<List<Warehouse>> {
            Data = warehouses
        };

        return response;
    }

    public async Task<ErrorOr<ServiceResponse<Warehouse>>> UpdateWarehouse(int warehouseId, Warehouse warehouse)
    {
        await Task.CompletedTask;

        var warehouseDb = await _warehouseRepository.GetWarehouseById(warehouseId);

        if (warehouseDb is null)
        {
           return ErrorHandling.Application.Errors.Warehouse.WarehouseNotFound;
        } 

        await _warehouseRepository.UpdateWarehouse(warehouseDb.Id, warehouse);

        // TODO: Re-query the object
        
        var response = new ServiceResponse<Warehouse> {
            Data = warehouse,
            Message = "Warehouse updated."
        };

        return response;
    }
}