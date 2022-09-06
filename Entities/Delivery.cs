namespace wms.Entites;

public class Delivery: IEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public float Value { get; set; }
    public float Weight { get; set; }
    public float Area { get; set; }
    // TODO: Add from and to
    public Warehouse WarehouseFrom { get; set; }
    public Warehouse WarehouseTo { get; set; }
    public Truck Truck { get; set; }
    public User DrivenBy { get; set; } 
    public List<Package> Packages { get; set; }
}