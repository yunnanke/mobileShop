using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("ремонт_устройств", Schema = "салон_сотовой_связи")]
public class DeviceRepair : IEntity
{
    [Key]
    [Column("id_ремонта")]
    public int Id { get; set; }

    [Column("id_клиента")]
    public int ClientId { get; set; }

    [Column("id_устройства")]
    public int? DeviceId { get; set; }

    [Column("серийный_номер")]
    public string? SerialNumber { get; set; }

    [Column("тип_неисправности")]
    [MaxLength(200)]
    public string FaultType { get; set; } = string.Empty;

    [Column("описание_проблемы")]
    public string? ProblemDescription { get; set; }

    [Column("статус")]
    [MaxLength(30)]
    public string? Status { get; set; }

    [Column("дата_приема")]
    public DateOnly AcceptanceDate { get; set; }

    [Column("дата_выдачи")]
    public DateOnly? IssueDate { get; set; }

    [Column("стоимость_ремонта", TypeName = "decimal(10,2)")]
    public decimal? RepairCost { get; set; }

    [Column("id_сотрудника")]
    public int? EmployeeId { get; set; }

    [Column("примечания")]
    public string? Notes { get; set; }
}
