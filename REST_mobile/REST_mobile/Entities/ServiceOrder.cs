using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("заказы_на_услуги", Schema = "салон_сотовой_связи")]
public class ServiceOrder : IEntity
{
    [Column("id_договора")]
    public int ContractId { get; set; }

    [Column("id_услуги")]
    public int ServiceId { get; set; }

    [Column("id_сотрудника")]
    public int EmployeeId { get; set; }

    [Column("дата_выполнения")]
    public DateOnly? ExecutionDate { get; set; }

    [Column("статус")]
    public string? Status { get; set; }

    [Column("примечания")]
    public string? Notes { get; set; }
}
