using Microsoft.EntityFrameworkCore;
using REST_mobile.Data;
using REST_mobile.Entities;
using Xunit;

namespace REST_mobile.Tests;

public class MobileShopDbContextTests
{
    [Fact]
    public void Model_RegistersMissingDumpTables()
    {
        using var context = CreateContext();

        Assert.NotNull(context.Model.FindEntityType(typeof(LoginAuditLog)));
        Assert.NotNull(context.Model.FindEntityType(typeof(Session)));
        Assert.NotNull(context.Model.FindEntityType(typeof(EmployeeAccount)));
    }

    [Fact]
    public void Model_ConfiguresCompositeKeys()
    {
        using var context = CreateContext();

        AssertKey<PurchaseItem>(context, nameof(PurchaseItem.PurchaseId), nameof(PurchaseItem.SerialNumber));
        AssertKey<SaleItem>(context, nameof(SaleItem.SaleId), nameof(SaleItem.SerialNumber));
        AssertKey<ServiceOrder>(context, nameof(ServiceOrder.ContractId), nameof(ServiceOrder.ServiceId));
    }

    [Fact]
    public void Model_ConfiguresBonusProgramSingleKey()
    {
        using var context = CreateContext();

        AssertKey<BonusProgram>(context, nameof(BonusProgram.ClientId));
    }

    [Fact]
    public void Model_ConfiguresKeysForAddedEntities()
    {
        using var context = CreateContext();

        AssertKey<LoginAuditLog>(context, nameof(LoginAuditLog.Id));
        AssertKey<Session>(context, nameof(Session.Id));
        AssertKey<EmployeeAccount>(context, nameof(EmployeeAccount.Id));
    }

    private static MobileShopDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MobileShopDbContext>()
            .UseNpgsql("Host=localhost;Database=test;Username=test;Password=test")
            .Options;
        return new MobileShopDbContext(options);
    }

    private static void AssertKey<TEntity>(MobileShopDbContext context, params string[] propertyNames)
        where TEntity : class
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        Assert.NotNull(entityType);

        var key = entityType!.FindPrimaryKey();
        Assert.NotNull(key);
        Assert.Equal(propertyNames, key!.Properties.Select(x => x.Name));
    }
}
