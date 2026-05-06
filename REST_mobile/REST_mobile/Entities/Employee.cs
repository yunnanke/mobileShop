using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("сотрудники", Schema = "салон_сотовой_связи")]
public class Employee : IEntity
{
    [Key]
    [Column("id_сотрудника")]
    public int Id { get; set; }

    [Column("фамилия")]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Column("имя")]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Column("отчество")]
    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Column("телефон")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [Column("email")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Column("id_должности")]
    public int PositionId { get; set; }

    [Column("дата_приёма")]
    public DateOnly HireDate { get; set; }

    [Column("зарплата", TypeName = "decimal(10,2)")]
    public decimal Salary { get; set; }
}
