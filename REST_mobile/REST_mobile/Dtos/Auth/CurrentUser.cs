namespace REST_mobile.Dtos.Auth;

public sealed class CurrentUser
{
    public int UserId { get; set; }

    public string UserType { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}
