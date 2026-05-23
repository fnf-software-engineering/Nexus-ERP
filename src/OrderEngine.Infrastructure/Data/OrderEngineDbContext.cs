using Microsoft.EntityFrameworkCore;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Data;

public class OrderEngineDbContext : DbContext
{
    public OrderEngineDbContext(DbContextOptions<OrderEngineDbContext> options) : base(options)
    {
    }
    
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();
    public DbSet<Products> Products => Set<Products>();
    public DbSet<InventoryMovementType> InventoryMovementTypes => Set<InventoryMovementType>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<StockMovementItems> StockMovementItems => Set<StockMovementItems>();
    public DbSet<UnitsMeasurement> UnitsMeasurements => Set<UnitsMeasurement>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Profiles> Profiles => Set<Profiles>();
    public DbSet<Permissions> Permissions => Set<Permissions>();
    public DbSet<PermissionsProfile> PermissionsProfiles => Set<PermissionsProfile>();
    public DbSet<UserProfiles> UserProfiles => Set<UserProfiles>();
    public DbSet<CompanyBranchUser> CompanyBranchUsers => Set<CompanyBranchUser>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<ThirdBranch> ThirdBranches => Set<ThirdBranch>();
    public DbSet<ThirdParty> ThirdParties => Set<ThirdParty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderEngineDbContext).Assembly);
    }
    
}