namespace go_horse_voos_comerciais.Domain.Passagem;

public interface IPassagensService
{
    List<Passagens> GerarPassagens(long idReserva, int quantidadeAssentosDesejados);
    void RealizarCheckIn(long idPassagem, int numeroAssentoDesejado);
}
