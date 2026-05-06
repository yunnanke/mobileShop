using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("должности", Schema = "салон_сотовой_связи")]
public class Position : IEntity
{
    [Key]
    [Column("id_должности")]
    public int Id { get; set; }

    [Column("название_должности")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("базовая_ставка", TypeName = "decimal(10,2)")]
    public decimal BaseRate { get; set; }
}
