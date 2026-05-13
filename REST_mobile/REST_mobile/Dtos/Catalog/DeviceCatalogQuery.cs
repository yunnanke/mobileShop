namespace REST_mobile.Dtos.Catalog;

public sealed class DeviceCatalogQuery
{
    public int? CategoryId { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public int Limit { get; set; } = 12;

    public int Offset { get; set; }
}
