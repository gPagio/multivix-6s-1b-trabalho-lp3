using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using go_horse_voos_comerciais.Domain.Reserva;

namespace go_horse_voos_comerciais.Domain.Passagem;

[Table("passagens")]
public class Passagens
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set;}

    [Column("id_reserva")]
    public long IdReserva { get; set;}

    public Reservas? Reserva { get; set;}

    [Column("numero_assento")]
    public int NumeroAssento { get; set;}

    [EnumDataType(typeof(StatusReserva))]
    [Column("checkin")]
    public SituacaoCheckIn CheckIn { get; set;}
}