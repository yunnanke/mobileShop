using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("устройства", Schema = "салон_сотовой_связи")]
public class Device : IEntity
{
    [Key]
    [Column("id_устройства")]
    public int Id { get; set; }

    [Column("id_производителя")]
    public int ManufacturerId { get; set; }

    [Column("id_категории")]
    public int CategoryId { get; set; }

    [Column("модель")]
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [Column("характеристики")]
    public string? Specifications { get; set; }

    [Column("розничная_цена", TypeName = "decimal(10,2)")]
    public decimal RetailPrice { get; set; }
}
