using Microsoft.EntityFrameworkCore;
using REST_mobile.Entities;

namespace REST_mobile.Data;

public class MobileShopDbContext(DbContextOptions<MobileShopDbContext> options) : DbContext(options)
{
    public DbSet<MobileOperator> MobileOperators => Set<MobileOperator>();
    public DbSet<TariffPlan> TariffPlans => Set<TariffPlan>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<SimCard> SimCards => Set<SimCard>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<DeviceManufacturer> DeviceManufacturers => Set<DeviceManufacturer>();
    public DbSet<DeviceCategory> DeviceCategories => Set<DeviceCategory>();
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseItem> PurchaseItems => Set<PurchaseItem>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
    public DbSet<Warranty> Warranties => Set<Warranty>();
    public DbSet<ShopService> ShopServices => Set<ShopService>();
    public DbSet<ServiceOrder> ServiceOrders => Set<ServiceOrder>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PromotionDiscount> PromotionDiscounts => Set<PromotionDiscount>();
    public DbSet<CustomerRequest> CustomerRequests => Set<CustomerRequest>();
    public DbSet<BonusProgram> BonusPrograms => Set<BonusProgram>();
    public DbSet<DeviceRepair> DeviceRepairs => Set<DeviceRepair>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PurchaseItem>()
            .HasKey(x => new { x.PurchaseId, x.SerialNumber });

        modelBuilder.Entity<SaleItem>()
            .HasKey(x => new { x.SaleId, x.SerialNumber });

        modelBuilder.Entity<ServiceOrder>()
            .HasKey(x => new { x.ContractId, x.ServiceId });

        modelBuilder.Entity<BonusProgram>()
            .HasKey(x => x.ClientId);
    }
}
