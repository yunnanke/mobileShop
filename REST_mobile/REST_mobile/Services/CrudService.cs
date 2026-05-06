using REST_mobile.Repositories;

namespace REST_mobile.Services;

public class CrudService<TEntity>(ICrudRepository<TEntity> repository) : ICrudService<TEntity>
    where TEntity : class
{
    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => repository.GetAllAsync(cancellationToken);

    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => repository.AddAsync(entity, cancellationToken);

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        => repository.UpdateAsync(entity, cancellationToken);

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        => repository.DeleteAsync(entity, cancellationToken);
}
