namespace REST_mobile.Dtos.Auth;

public sealed class LoginResponse
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public string? Token { get; set; }

    public string? Role { get; set; }

    public string? UserType { get; set; }

    public int? UserId { get; set; }

    public string? DisplayName { get; set; }
}
