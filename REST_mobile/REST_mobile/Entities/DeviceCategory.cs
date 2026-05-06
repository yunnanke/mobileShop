using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("категории_устройств", Schema = "салон_сотовой_связи")]
public class DeviceCategory : IEntity
{
    [Key]
    [Column("id_категории")]
    public int Id { get; set; }

    [Column("название_категории")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("описание_категории")]
    public string? Description { get; set; }
}
