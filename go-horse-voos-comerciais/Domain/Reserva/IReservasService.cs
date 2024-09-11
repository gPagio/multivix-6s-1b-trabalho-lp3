namespace go_horse_voos_comerciais.Domain.Reserva;

public interface IReservasService
{
    Task<DadosListagemReservasDTO> CadastraReserva(long? idVoo, string cpfCliente, FormaPagamento? formaPagamento, int? quantidadeAssentosDesejados);
    Task<DadosListagemReservasDTO> CancelaReserva(long? idReserva);
}