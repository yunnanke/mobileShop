namespace REST_mobile.Dtos.Catalog;

public sealed class PromotionCatalogItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DiscountType { get; set; } = string.Empty;

    public decimal DiscountValue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? Description { get; set; }
}
