namespace wms.Entites;

public class Truck: IEntity
{
    public string Title { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public float AreaCapacity { get; set; }
    public float WeightCapacity { get; set; }
    public List<User>? Drivers { get; set; }
}