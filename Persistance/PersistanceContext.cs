using Microsoft.EntityFrameworkCore;
using wms.Entites;

namespace wms.Persistance;

public class PersistanceContext : DbContext
{
    public PersistanceContext(DbContextOptions<PersistanceContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Brian", LastName = "Brown", UserType = Enums.UserType.WarehouseAdministrator, Email = "brian.brown@wms.com", Password = "1234" },
            new User { Id = 2, FirstName = "Andrew", LastName = "White", UserType = Enums.UserType.Driver, Email = "andrew.white@wms.com", Password = "5678" }
        );
    }

}