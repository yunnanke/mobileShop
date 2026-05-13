using REST_mobile.Repositories;
using REST_mobile.Services;
using Xunit;

namespace REST_mobile.Tests;

public class CrudServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsRepositoryResult()
    {
        var expected = new List<TestEntity> { new() { Id = 1 }, new() { Id = 2 } };
        var repository = new FakeCrudRepository { GetAllResult = expected };
        var service = new CrudService<TestEntity>(repository);

        var result = await service.GetAllAsync();

        Assert.Same(expected, result);
        Assert.True(repository.GetAllCalled);
    }

    [Fact]
    public async Task AddAsync_DelegatesToRepository()
    {
        var entity = new TestEntity { Id = 7 };
        var repository = new FakeCrudRepository();
        var service = new CrudService<TestEntity>(repository);

        var result = await service.AddAsync(entity);

        Assert.Same(entity, result);
        Assert.Same(entity, repository.AddedEntity);
    }

    [Fact]
    public async Task UpdateAsync_DelegatesToRepository()
    {
        var entity = new TestEntity { Id = 9 };
        var repository = new FakeCrudRepository();
        var service = new CrudService<TestEntity>(repository);

        var result = await service.UpdateAsync(entity);

        Assert.Same(entity, result);
        Assert.Same(entity, repository.UpdatedEntity);
    }

    [Fact]
    public async Task DeleteAsync_DelegatesToRepository()
    {
        var entity = new TestEntity { Id = 11 };
        var repository = new FakeCrudRepository();
        var service = new CrudService<TestEntity>(repository);

        await service.DeleteAsync(entity);

        Assert.Same(entity, repository.DeletedEntity);
    }

    private sealed class FakeCrudRepository : ICrudRepository<TestEntity>
    {
        public List<TestEntity> GetAllResult { get; init; } = [];
        public bool GetAllCalled { get; private set; }
        public TestEntity? AddedEntity { get; private set; }
        public TestEntity? UpdatedEntity { get; private set; }
        public TestEntity? DeletedEntity { get; private set; }

        public Task<List<TestEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            GetAllCalled = true;
            return Task.FromResult(GetAllResult);
        }

        public Task<TestEntity> AddAsync(TestEntity entity, CancellationToken cancellationToken = default)
        {
            AddedEntity = entity;
            return Task.FromResult(entity);
        }

        public Task<TestEntity> UpdateAsync(TestEntity entity, CancellationToken cancellationToken = default)
        {
            UpdatedEntity = entity;
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(TestEntity entity, CancellationToken cancellationToken = default)
        {
            DeletedEntity = entity;
            return Task.CompletedTask;
        }
    }

    private sealed class TestEntity
    {
        public int Id { get; init; }
    }
}
