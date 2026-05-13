namespace REST_mobile.Dtos.Staff;

public sealed class CreateRepairRequest
{
    public int ClientId { get; set; }

    public int? DeviceId { get; set; }

    public string? SerialNumber { get; set; }

    public string FaultType { get; set; } = string.Empty;

    public string? ProblemDescription { get; set; }
}
