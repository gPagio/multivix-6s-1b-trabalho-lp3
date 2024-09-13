namespace go_horse_voos_comerciais.Domain.Reserva;

public interface IReservasService
{
    Task<DadosListagemReservasDTO> CadastraReserva(long? idVoo, string cpfCliente, FormaPagamento? formaPagamento, int? quantidadeAssentosDesejados);
    void CancelaReserva(long? idReserva);
    public Task<IEnumerable<DadosListagemReservasDTO>> ListaReservas();
}