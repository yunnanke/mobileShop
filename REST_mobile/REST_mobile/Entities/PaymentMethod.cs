using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("способы_оплаты", Schema = "салон_сотовой_связи")]
public class PaymentMethod : IEntity
{
    [Key]
    [Column("id_способа_оплаты")]
    public int Id { get; set; }

    [Column("название_способа_оплаты")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
}
