using wms.Entites;

namespace wms.Contracts.Package;

public record AddPackageRequest
(
    string Title,
    float Weight,
    float Area,
    float Value,
    Entites.Warehouse? StoredAtWarehouse,
    List<Delivery>? Deliveries
);