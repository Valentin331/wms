using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace wms.Entites;

public class Warehouse : IEntity
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public List<User>? WarehouseAdministrators { get; set; }
    public List<Package>? Packages { get; set; }
}