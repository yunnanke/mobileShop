namespace REST_mobile.Dtos.Staff;

public sealed class CreateContractRequest
{
    public int ClientId { get; set; }

    public string SimIccid { get; set; } = string.Empty;

    public string ContractType { get; set; } = string.Empty;
}
