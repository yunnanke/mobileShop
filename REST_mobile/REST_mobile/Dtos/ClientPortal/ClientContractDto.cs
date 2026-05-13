namespace REST_mobile.Dtos.ClientPortal;

public sealed class ClientContractDto
{
    public int ContractId { get; set; }

    public string Type { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Details { get; set; }

    public string? SimPhoneNumber { get; set; }

    public string? SimIccid { get; set; }
}
