using go_horse_voos_comerciais.Domain.Cliente;
using go_horse_voos_comerciais.Domain.Passagem;
using go_horse_voos_comerciais.Domain.Voo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace go_horse_voos_comerciais.Domain.Reserva;

[Table("reservas")]
public class Reservas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_cliente")]
    public long IdCliente { get; set; }

    public Clientes Cliente { get; set; }

    [Column("data_reserva")]
    public DateTime DataReserva { get; set; }

    [EnumDataType(typeof(FormaPagamento))]
    [Column("forma_pagamento")]
    public FormaPagamento FormaPagamento{ get; set; }

    [Column("id_voo")]
    public long IdVoo { get; set; }

    public Voos Voo { get; set; }

    public ICollection<Passagens>? Passagens { get; set;}

    [EnumDataType(typeof(StatusReserva))]
    [Column("status_reserva")]
    public StatusReserva StatusReserva { get; set; }

    public Reservas() { }

    public Reservas(long idVoo, long idCliente, FormaPagamento formaPagamento)
    {
        this.IdCliente = idCliente;
        this.DataReserva = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        this.FormaPagamento = formaPagamento;
        this.IdVoo = idVoo;
        this.StatusReserva = StatusReserva.CONFIRMADA;
    }
}