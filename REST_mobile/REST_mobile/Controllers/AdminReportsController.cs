using Microsoft.AspNetCore.Mvc;
using REST_mobile.Dtos.Admin;
using REST_mobile.Dtos.Auth;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
[Route("api/admin-reports")]
public sealed class AdminReportsController(
    DatabaseAuthService authService,
    PortalQueryService portalQueryService) : ControllerBase
{
    [HttpGet("employee-performance")]
    public async Task<ActionResult<List<EmployeePerformanceDto>>> GetEmployeePerformance(CancellationToken cancellationToken)
    {
        var currentUser = await authService.ValidateTokenAsync(Request.Headers.Authorization, cancellationToken);
        if (currentUser is null || !string.Equals(currentUser.Role, "admin", StringComparison.OrdinalIgnoreCase))
        {
            return Unauthorized();
        }

        return Ok(await portalQueryService.GetEmployeePerformanceAsync(cancellationToken));
    }
}
