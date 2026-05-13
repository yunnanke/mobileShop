using Microsoft.AspNetCore.Mvc;
using REST_mobile.Dtos.Auth;
using REST_mobile.Dtos.Staff;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
[Route("api/staff-operations")]
public sealed class StaffOperationsController(
    DatabaseAuthService authService,
    PortalQueryService portalQueryService) : ControllerBase
{
    [HttpGet("clients/search")]
    public async Task<ActionResult<List<ClientLookupDto>>> SearchClients([FromQuery] string? query, CancellationToken cancellationToken)
    {
        if (await RequireUserAsync(cancellationToken, "consultant", "admin") is null)
        {
            return Unauthorized();
        }

        return Ok(await portalQueryService.SearchClientsAsync(query, cancellationToken));
    }

    [HttpPost("sales")]
    public async Task<ActionResult<object>> RegisterSale([FromBody] RegisterSaleRequest request, CancellationToken cancellationToken)
    {
        var currentUser = await RequireUserAsync(cancellationToken, "consultant", "admin");
        if (currentUser is null)
        {
            return Unauthorized();
        }

        var saleId = await portalQueryService.RegisterSaleAsync(request, currentUser.UserId, cancellationToken);
        return Ok(new { saleId });
    }

    [HttpPost("repairs")]
    public async Task<ActionResult<object>> CreateRepair([FromBody] CreateRepairRequest request, CancellationToken cancellationToken)
    {
        var currentUser = await RequireUserAsync(cancellationToken, "consultant", "admin");
        if (currentUser is null)
        {
            return Unauthorized();
        }

        var repairId = await portalQueryService.CreateRepairAsync(request, currentUser.UserId, cancellationToken);
        return Ok(new { repairId });
    }

    [HttpPut("repairs/{repairId:int}/close")]
    public async Task<IActionResult> CloseRepair(int repairId, [FromBody] CloseRepairRequest request, CancellationToken cancellationToken)
    {
        if (await RequireUserAsync(cancellationToken, "consultant", "admin") is null)
        {
            return Unauthorized();
        }

        await portalQueryService.CloseRepairAsync(repairId, request, cancellationToken);
        return NoContent();
    }

    [HttpPost("contracts")]
    public async Task<ActionResult<object>> CreateContract([FromBody] CreateContractRequest request, CancellationToken cancellationToken)
    {
        var currentUser = await RequireUserAsync(cancellationToken, "consultant", "admin");
        if (currentUser is null)
        {
            return Unauthorized();
        }

        var contractId = await portalQueryService.CreateContractAsync(request, currentUser.UserId, cancellationToken);
        return Ok(new { contractId });
    }

    private async Task<CurrentUser?> RequireUserAsync(CancellationToken cancellationToken, params string[] roles)
    {
        var currentUser = await authService.ValidateTokenAsync(Request.Headers.Authorization, cancellationToken);
        if (currentUser is null)
        {
            return null;
        }

        return roles.Contains(currentUser.Role, StringComparer.OrdinalIgnoreCase)
            ? currentUser
            : null;
    }
}
