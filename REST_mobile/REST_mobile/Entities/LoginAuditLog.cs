using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("журнал_входов", Schema = "салон_сотовой_связи")]
public class LoginAuditLog : IEntity
{
    [Key]
    [Column("id_входа")]
    public long Id { get; set; }

    [Column("тип_пользователя")]
    [MaxLength(20)]
    public string UserType { get; set; } = string.Empty;

    [Column("id_пользователя")]
    public int UserId { get; set; }

    [Column("время_входа")]
    public DateTime? LoginTime { get; set; }

    [Column("ip_адрес", TypeName = "inet")]
    public IPAddress? IpAddress { get; set; }

    [Column("user_agent")]
    public string? UserAgent { get; set; }

    [Column("токен")]
    [MaxLength(256)]
    public string? Token { get; set; }
}
