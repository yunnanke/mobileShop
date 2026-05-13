namespace REST_mobile.Dtos.ClientPortal;

public sealed class ClientBonusDto
{
    public int ClientId { get; set; }

    public string? ClientLevel { get; set; }

    public int BonusPoints { get; set; }

    public DateOnly? LastAccrualDate { get; set; }
}
