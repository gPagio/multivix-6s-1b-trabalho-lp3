using go_horse_voos_comerciais.Domain.Passagem;

public class Passagens
{
    public long Id { get; set;}
    public long IdReserva { get; set;}
    public int NumeroAssento { get; set;}
    public SituacaoCheckIn CheckIn { get; set;}
}