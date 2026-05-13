namespace REST_mobile.Dtos.Catalog;

public sealed class TariffCatalogItemDto
{
    public int Id { get; set; }

    public string OperatorName { get; set; } = string.Empty;

    public string TariffName { get; set; } = string.Empty;

    public decimal MonthlyFee { get; set; }

    public int IncludedMinutes { get; set; }

    public int IncludedSms { get; set; }

    public decimal IncludedInternetGb { get; set; }

    public string? Description { get; set; }
}
