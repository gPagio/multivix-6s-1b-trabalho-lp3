namespace go_horse_voos_comerciais.Domain.Reserva;
public class Reservas
{
    public long Id { get; set; }
    public long IdCliente { get; set; }
    public DateTime DataReserva { get; set; }
    public FormaPagamento FormaPagamento{ get; set; }
    public long IdVoo { get; set; }
    public List<Passagens>? PassagemList { get; set;}
    public StatusReserva Status { get; set; }

    public Reservas() { }
}