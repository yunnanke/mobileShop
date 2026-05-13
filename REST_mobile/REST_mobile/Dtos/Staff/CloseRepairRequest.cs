namespace REST_mobile.Dtos.Staff;

public sealed class CloseRepairRequest
{
    public decimal FinalCost { get; set; }

    public string? Notes { get; set; }
}
