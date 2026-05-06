using System.ComponentModel.DataAnnotations.Schema;
using REST_mobile.Abstractions;

namespace REST_mobile.Entities;

[Table("бонусная_программа", Schema = "салон_сотовой_связи")]
public class BonusProgram : IEntity
{
    [Column("id_клиента")]
    public int ClientId { get; set; }

    [Column("количество_баллов")]
    public int Points { get; set; }

    [Column("дата_последнего_начисления")]
    public DateOnly? LastAccrualDate { get; set; }

    [Column("уровень_клиента")]
    public string? ClientLevel { get; set; }
}
