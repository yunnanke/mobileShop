using Microsoft.AspNetCore.Mvc;
using REST_mobile.Dtos.Auth;
using REST_mobile.Dtos.ClientPortal;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
[Route("api/client-portal")]
public sealed class ClientPortalController(
    DatabaseAuthService authService,
    PortalQueryService portalQueryService) : ControllerBase
{
    [HttpGet("profile")]
    public async Task<ActionResult<ClientProfileDto>> GetProfile(CancellationToken cancellationToken)
    {
        var user = await RequireUserAsync(cancellationToken, "client", "admin");
        if (user is null)
        {
            return Unauthorized();
        }

        var profile = await portalQueryService.GetClientProfileAsync(user.UserId, cancellationToken);
        return profile is null ? NotFound() : Ok(profile);
    }

    [HttpGet("repairs")]
    public async Task<ActionResult<List<ClientRepairDto>>> GetRepairs(CancellationToken cancellationToken)
    {
        var user = await RequireUserAsync(cancellationToken, "client", "admin");
        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(await portalQueryService.GetClientRepairsAsync(user.UserId, cancellationToken));
    }

    [HttpGet("contracts")]
    public async Task<ActionResult<List<ClientContractDto>>> GetContracts(CancellationToken cancellationToken)
    {
        var user = await RequireUserAsync(cancellationToken, "client", "admin");
        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(await portalQueryService.GetClientContractsAsync(user.UserId, cancellationToken));
    }

    [HttpGet("bonus")]
    public async Task<ActionResult<ClientBonusDto>> GetBonus(CancellationToken cancellationToken)
    {
        var user = await RequireUserAsync(cancellationToken, "client", "admin");
        if (user is null)
        {
            return Unauthorized();
        }

        var bonus = await portalQueryService.GetClientBonusAsync(user.UserId, cancellationToken);
        return bonus is null ? NotFound() : Ok(bonus);
    }

    [HttpGet("purchases")]
    public async Task<ActionResult<List<ClientPurchaseDto>>> GetPurchases(CancellationToken cancellationToken)
    {
        var user = await RequireUserAsync(cancellationToken, "client", "admin");
        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(await portalQueryService.GetClientPurchasesAsync(user.UserId, cancellationToken));
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
