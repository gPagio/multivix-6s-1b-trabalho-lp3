namespace go_horse_voos_comerciais.Domain.Passagem;

public record DadosListagemPassagensDTO (long id, long idReserva, int numeroAssento, SituacaoCheckIn checkIn)
{
    public DadosListagemPassagensDTO(Passagens passagens) : this(passagens.Id, passagens.IdReserva, passagens.NumeroAssento, passagens.SituacaoCheckIn) { }
}