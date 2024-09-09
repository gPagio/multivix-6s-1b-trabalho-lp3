using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace go_horse_voos_comerciais.Domain.Reserva;
public class Reservas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_cliente")]
    public long IdCliente { get; set; }

    [Column("data_reserva")]
    public DateTime DataReserva { get; set; }

    [EnumDataType(typeof(FormaPagamento))]
    [Column("forma_pagamento")]
    public FormaPagamento FormaPagamento{ get; set; }

    [Column("id_voo")]
    public long IdVoo { get; set; }

    [Column("id")]
    public List<Passagens>? PassagemList { get; set;}

    [EnumDataType(typeof(StatusReserva))]
    [Column("status")]
    public StatusReserva Status { get; set; }

    public Reservas() { }
}