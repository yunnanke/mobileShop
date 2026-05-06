using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("позиции_продаж", Schema = "салон_сотовой_связи")]
public class SaleItem : IEntity
{
    [Column("id_продажи")]
    public int SaleId { get; set; }

    [Column("id_устройства")]
    public int DeviceId { get; set; }

    [Column("серийный_номер")]
    public string SerialNumber { get; set; } = string.Empty;
}
