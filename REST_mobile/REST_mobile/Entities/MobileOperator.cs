using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("мобильные_операторы", Schema = "салон_сотовой_связи")]
public class MobileOperator : IEntity
{
    [Key]
    [Column("id_оператора")]
    public int Id { get; set; }

    [Column("название_оператора")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("контактная_информация")]
    public string? ContactInformation { get; set; }
}
