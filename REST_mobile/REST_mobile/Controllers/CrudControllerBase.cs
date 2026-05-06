using Microsoft.AspNetCore.Mvc;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
public abstract class CrudControllerBase<TEntity>(ICrudService<TEntity> service) : ControllerBase
    where TEntity : class
{
    [HttpGet]
    public async Task<ActionResult<List<TEntity>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity, CancellationToken cancellationToken)
    {
        var created = await service.AddAsync(entity, cancellationToken);
        return Ok(created);
    }

    [HttpPut]
    public async Task<ActionResult<TEntity>> Update([FromBody] TEntity entity, CancellationToken cancellationToken)
    {
        var updated = await service.UpdateAsync(entity, cancellationToken);
        return Ok(updated);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] TEntity entity, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(entity, cancellationToken);
        return NoContent();
    }
}
