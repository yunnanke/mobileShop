namespace REST_mobile.Dtos.Staff;

public sealed class ClientLookupDto
{
    public int ClientId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? Email { get; set; }
}
