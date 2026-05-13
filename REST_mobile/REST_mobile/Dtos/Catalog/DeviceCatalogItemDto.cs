namespace REST_mobile.Dtos.Catalog;

public sealed class DeviceCatalogItemDto
{
    public int Id { get; set; }

    public string Model { get; set; } = string.Empty;

    public string? Specifications { get; set; }

    public decimal RetailPrice { get; set; }

    public string ManufacturerName { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public int StockCount { get; set; }
}
