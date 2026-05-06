using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("тарифные_планы", Schema = "салон_сотовой_связи")]
public class TariffPlan : IEntity
{
    [Key]
    [Column("id_тарифа")]
    public int Id { get; set; }

    [Column("id_оператора")]
    public int MobileOperatorId { get; set; }

    [Column("название_тарифа")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("ежемесячная_плата", TypeName = "decimal(10,2)")]
    public decimal MonthlyFee { get; set; }

    [Column("включённые_минуты")]
    public int IncludedMinutes { get; set; }

    [Column("включённые_sms")]
    public int? IncludedSms { get; set; }

    [Column("включённый_интернет_гб", TypeName = "decimal(5,2)")]
    public decimal IncludedInternetGb { get; set; }

    [Column("описание")]
    public string? Description { get; set; }
}
