using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("производители_устройств", Schema = "салон_сотовой_связи")]
public class DeviceManufacturer : IEntity
{
    [Key]
    [Column("id_производителя")]
    public int Id { get; set; }

    [Column("название_производителя")]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
}
