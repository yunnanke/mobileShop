using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("договоры", Schema = "салон_сотовой_связи")]
public class Contract : IEntity
{
    [Key]
    [Column("id_договора")]
    public int Id { get; set; }

    [Column("id_клиента")]
    public int ClientId { get; set; }

    [Column("id_сотрудника")]
    public int EmployeeId { get; set; }

    [Column("тип_договора")]
    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;

    [Column("дата_начала")]
    public DateOnly StartDate { get; set; }

    [Column("дата_окончания")]
    public DateOnly? EndDate { get; set; }

    [Column("детали_договора")]
    public string? Details { get; set; }
}
