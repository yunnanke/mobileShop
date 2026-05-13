using Microsoft.AspNetCore.Mvc;
using REST_mobile.Controllers;
using REST_mobile.Services;
using Xunit;

namespace REST_mobile.Tests;

public class CrudControllerBaseTests
{
    [Fact]
    public async Task GetAll_ReturnsOkWithEntities()
    {
        var entities = new List<TestEntity> { new() { Id = 1 }, new() { Id = 2 } };
        var service = new FakeCrudService { GetAllResult = entities };
        var controller = new TestCrudController(service);

        var actionResult = await controller.GetAll(CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Same(entities, okResult.Value);
    }

    [Fact]
    public async Task Create_ReturnsOkWithCreatedEntity()
    {
        var entity = new TestEntity { Id = 5 };
        var service = new FakeCrudService();
        var controller = new TestCrudController(service);

        var actionResult = await controller.Create(entity, CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Same(entity, okResult.Value);
        Assert.Same(entity, service.AddedEntity);
    }

    [Fact]
    public async Task Update_ReturnsOkWithUpdatedEntity()
    {
        var entity = new TestEntity { Id = 8 };
        var service = new FakeCrudService();
        var controller = new TestCrudController(service);

        var actionResult = await controller.Update(entity, CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Same(entity, okResult.Value);
        Assert.Same(entity, service.UpdatedEntity);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent()
    {
        var entity = new TestEntity { Id = 12 };
        var service = new FakeCrudService();
        var controller = new TestCrudController(service);

        var result = await controller.Delete(entity, CancellationToken.None);

        Assert.IsType<NoContentResult>(result);
        Assert.Same(entity, service.DeletedEntity);
    }

    private sealed class TestCrudController(ICrudService<TestEntity> service)
        : CrudControllerBase<TestEntity>(service);

    private sealed class FakeCrudService : ICrudService<TestEntity>
    {
        public List<TestEntity> GetAllResult { get; init; } = [];
        public TestEntity? AddedEntity { get; private set; }
        public TestEntity? UpdatedEntity { get; private set; }
        public TestEntity? DeletedEntity { get; private set; }

        public Task<List<TestEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(GetAllResult);

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
