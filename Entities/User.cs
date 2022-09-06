using wms.Enums;

namespace wms.Entites;

public class User : IUser {
    public UserType UserType { get; set; }
    public Warehouse? AdminToWarehouse { get; set; }
    public List<Truck>? Trucks { get; set; }
}