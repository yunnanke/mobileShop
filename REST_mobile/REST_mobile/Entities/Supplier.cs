using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("поставщики", Schema = "салон_сотовой_связи")]
public class Supplier : IEntity
{
    [Key]
    [Column("id_поставщика")]
    public int Id { get; set; }

    [Column("название_компании")]
    [MaxLength(150)]
    public string CompanyName { get; set; } = string.Empty;

    [Column("адрес")]
    public string? Address { get; set; }

    [Column("телефон")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [Column("email")]
    [MaxLength(100)]
    public string? Email { get; set; }
}
