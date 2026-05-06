using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("услуги", Schema = "салон_сотовой_связи")]
public class ShopService : IEntity
{
    [Key]
    [Column("id_услуги")]
    public int Id { get; set; }

    [Column("название_услуги")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("описание_услуги")]
    public string? Description { get; set; }

    [Column("стоимость", TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
}
