using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("позиции_закупок", Schema = "салон_сотовой_связи")]
public class PurchaseItem : IEntity
{
    [Column("id_закупки")]
    public int PurchaseId { get; set; }

    [Column("id_устройства")]
    public int DeviceId { get; set; }

    [Column("серийный_номер")]
    public string SerialNumber { get; set; } = string.Empty;

    [Column("цена_за_единицу", TypeName = "decimal(10,2)")]
    public decimal UnitPrice { get; set; }
}
