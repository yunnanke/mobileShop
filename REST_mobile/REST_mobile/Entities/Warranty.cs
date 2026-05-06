using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("гарантии", Schema = "салон_сотовой_связи")]
public class Warranty : IEntity
{
    [Key]
    [Column("id_гарантии")]
    public int Id { get; set; }

    [Column("серийный_номер")]
    public string SerialNumber { get; set; } = string.Empty;

    [Column("дата_начала_гарантии")]
    public DateOnly StartDate { get; set; }

    [Column("дата_окончания_гарантии")]
    public DateOnly? EndDate { get; set; }

    [Column("условия_гарантии")]
    public string? Terms { get; set; }

    [Column("активна")]
    public bool IsActive { get; set; }

    [Column("id_устройства")]
    public int? DeviceId { get; set; }
}
