using Microsoft.EntityFrameworkCore;
using REST_mobile.Data;

namespace REST_mobile.Repositories;

public class CrudRepository<TEntity>(MobileShopDbContext dbContext) : ICrudRepository<TEntity>
    where TEntity : class
{
    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Entry(entity).State = EntityState.Deleted;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
