namespace REST_mobile.Dtos.ClientPortal;

public sealed class ClientRepairDto
{
    public int RepairId { get; set; }

    public string? DeviceModel { get; set; }

    public string? SerialNumber { get; set; }

    public string FaultType { get; set; } = string.Empty;

    public string? Status { get; set; }

    public DateOnly AcceptedAt { get; set; }

    public DateOnly? IssuedAt { get; set; }

    public decimal? FinalCost { get; set; }
}
