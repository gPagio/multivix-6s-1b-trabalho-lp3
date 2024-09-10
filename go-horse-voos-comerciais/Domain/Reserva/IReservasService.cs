namespace go_horse_voos_comerciais.Domain.Reserva;

public interface IReservasService
{
    Task<Reservas> CadastraReserva(long idVoo, int quantidadeAssentos);
    Task<Reservas> CancelaReserva(long idReserva);
}