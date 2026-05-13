using Microsoft.AspNetCore.Mvc;
using REST_mobile.Dtos.Auth;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(DatabaseAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await authService.LoginAsync(request.Login, request.Password, cancellationToken);
        return response.Success ? Ok(response) : Unauthorized(response);
    }
}
