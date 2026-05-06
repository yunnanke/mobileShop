using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("sim_карты", Schema = "салон_сотовой_связи")]
public class SimCard : IEntity
{
    [Key]
    [Column("id_sim_карты")]
    public int Id { get; set; }

    [Column("iccid")]
    [MaxLength(20)]
    public string Iccid { get; set; } = string.Empty;

    [Column("номер_телефона")]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("id_тарифа")]
    public int TariffPlanId { get; set; }

    [Column("статус")]
    [MaxLength(20)]
    public string? Status { get; set; }

    [Column("дата_активации")]
    public DateOnly? ActivationDate { get; set; }

    [Column("id_договора")]
    public int? ContractId { get; set; }
}
