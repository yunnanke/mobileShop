using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("сессии", Schema = "салон_сотовой_связи")]
public class Session : IEntity
{
    [Key]
    [Column("id_сессии")]
    [MaxLength(128)]
    public string Id { get; set; } = string.Empty;

    [Column("Тип_пользователя")]
    [MaxLength(20)]
    public string UserType { get; set; } = string.Empty;

    [Column("id_пользователя")]
    public int UserId { get; set; }

    [Column("Токен_обновления")]
    [MaxLength(128)]
    public string? RefreshToken { get; set; }

    [Column("токен")]
    [MaxLength(256)]
    public string? Token { get; set; }

    [Column("ip_адрес", TypeName = "inet")]
    public IPAddress? IpAddress { get; set; }

    [Column("user_agent")]
    public string? UserAgent { get; set; }

    [Column("Время_создания")]
    public DateTime? CreatedAt { get; set; }

    [Column("Время_истечения")]
    public DateTime ExpiresAt { get; set; }

    [Column("Время_выхода")]
    public DateTime? LoggedOutAt { get; set; }

    [Column("Активна")]
    public bool? IsActive { get; set; }
}
