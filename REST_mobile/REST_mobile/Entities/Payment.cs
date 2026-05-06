using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("платежи", Schema = "салон_сотовой_связи")]
public class Payment : IEntity
{
    [Key]
    [Column("id_платежа")]
    public int Id { get; set; }

    [Column("id_договора")]
    public int ContractId { get; set; }

    [Column("id_способа_оплаты")]
    public int PaymentMethodId { get; set; }

    [Column("дата_платежа")]
    public DateOnly PaymentDate { get; set; }
}
