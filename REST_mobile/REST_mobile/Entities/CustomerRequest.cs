using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("обращения_клиентов", Schema = "салон_сотовой_связи")]
public class CustomerRequest : IEntity
{
    [Key]
    [Column("id_обращения")]
    public int Id { get; set; }

    [Column("id_клиента")]
    public int ClientId { get; set; }

    [Column("id_устройства")]
    public int? DeviceId { get; set; }

    [Column("id_сотрудника")]
    public int? EmployeeId { get; set; }

    [Column("тема")]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [Column("описание")]
    public string Description { get; set; } = string.Empty;

    [Column("статус")]
    [MaxLength(30)]
    public string? Status { get; set; }

    [Column("приоритет")]
    [MaxLength(20)]
    public string? Priority { get; set; }

    [Column("дата_создания")]
    public DateTime CreatedAt { get; set; }

    [Column("дата_решения")]
    public DateTime? ResolvedAt { get; set; }

    [Column("ответ")]
    public string? Response { get; set; }
}
