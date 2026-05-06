using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("закупки", Schema = "салон_сотовой_связи")]
public class Purchase : IEntity
{
    [Key]
    [Column("id_закупки")]
    public int Id { get; set; }

    [Column("id_поставщика")]
    public int SupplierId { get; set; }

    [Column("id_сотрудника")]
    public int? EmployeeId { get; set; }

    [Column("дата_закупки")]
    public DateOnly PurchaseDate { get; set; }
}
