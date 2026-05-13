namespace REST_mobile.Dtos.ClientPortal;

public sealed class ClientProfileDto
{
    public int ClientId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? Email { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public string? ClientLevel { get; set; }

    public int BonusPoints { get; set; }

    public DateOnly? LastAccrualDate { get; set; }

    public long ActiveContractsCount { get; set; }
}
