namespace wms.Contracts.Warehouse;

public record AddWarehouseRequest
(
    string Name,
    int Capacity
);