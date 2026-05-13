using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("учетные_записи_сотрудников", Schema = "салон_сотовой_связи")]
public class EmployeeAccount : IEntity
{
    [Key]
    [Column("id_учетной_записи")]
    public int Id { get; set; }

    [Column("id_сотрудника")]
    public int? EmployeeId { get; set; }

    [Column("Логин")]
    [MaxLength(100)]
    public string Login { get; set; } = string.Empty;

    [Column("Хеш_пароля")]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("Роль")]
    [MaxLength(50)]
    public string Role { get; set; } = string.Empty;

    [Column("Двухфакторный_ключ")]
    [MaxLength(32)]
    public string? TwoFactorKey { get; set; }

    [Column("Активен")]
    public bool? IsActive { get; set; }

    [Column("Попыток_входа")]
    public int? LoginAttempts { get; set; }

    [Column("Последний_вход")]
    public DateTime? LastLoginAt { get; set; }

    [Column("id_клиента")]
    public int? ClientId { get; set; }
}
