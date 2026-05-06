using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("клиенты", Schema = "салон_сотовой_связи")]
public class Client : IEntity
{
    [Key]
    [Column("id_клиента")]
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
    public string Phone { get; set; } = string.Empty;

    [Column("email")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Column("паспортные_данные")]
    public string? PassportData { get; set; }

    [Column("дата_регистрации")]
    public DateOnly RegistrationDate { get; set; }
}
