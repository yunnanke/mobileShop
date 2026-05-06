using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("акции_и_скидки", Schema = "салон_сотовой_связи")]
public class PromotionDiscount : IEntity
{
    [Key]
    [Column("id_акции")]
    public int Id { get; set; }

    [Column("название_акции")]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Column("тип_скидки")]
    [MaxLength(50)]
    public string DiscountType { get; set; } = string.Empty;

    [Column("размер_скидки", TypeName = "decimal(10,2)")]
    public decimal DiscountValue { get; set; }

    [Column("дата_начала")]
    public DateOnly StartDate { get; set; }

    [Column("дата_окончания")]
    public DateOnly EndDate { get; set; }

    [Column("описание")]
    public string? Description { get; set; }

    [Column("активна")]
    public bool IsActive { get; set; }
}
