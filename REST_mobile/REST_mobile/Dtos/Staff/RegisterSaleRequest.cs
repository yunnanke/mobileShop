namespace REST_mobile.Dtos.Staff;

public sealed class RegisterSaleRequest
{
    public int ClientId { get; set; }

    public string SerialNumbers { get; set; } = string.Empty;

    public int PaymentMethodId { get; set; }
}
