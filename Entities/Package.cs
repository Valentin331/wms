namespace wms.Entites;

public class Package: IEntity
{
    public string Title { get; set; } = string.Empty;
    public float Weight { get; set; }
    public float Area { get; set; }
    public float Value { get; set; }
    public Warehouse? StoredAtWarehouse { get; set; }
    public List<Delivery>? Deliveries { get; set; }
}