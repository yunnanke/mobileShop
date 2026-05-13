namespace REST_mobile.Dtos.ClientPortal;

public sealed class ClientPurchaseDto
{
    public int SaleId { get; set; }

    public DateOnly SaleDate { get; set; }

    public string DeviceModel { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public decimal RetailPrice { get; set; }
}
