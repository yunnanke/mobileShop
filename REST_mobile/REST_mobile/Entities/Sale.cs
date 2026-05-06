using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("продажи", Schema = "салон_сотовой_связи")]
public class Sale : IEntity
{
    [Key]
    [Column("id_продажи")]
    public int Id { get; set; }

    [Column("id_клиента")]
    public int ClientId { get; set; }

    [Column("id_сотрудника")]
    public int EmployeeId { get; set; }

    [Column("дата_продажи")]
    public DateOnly SaleDate { get; set; }
}
