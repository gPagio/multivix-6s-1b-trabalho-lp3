public class Reserva
{
    public long Id { get; set; }
    public long IdCliente { get; set; }
    public DateTime DataReserva { get; set; }
    public FormaPagamento FormaPagamento{ get; set; }
    public long IdVoo { get; set; }
    public List<Passagem>? PassagemList { get; set;}
    public StatusReserva Status { get; set; }
}