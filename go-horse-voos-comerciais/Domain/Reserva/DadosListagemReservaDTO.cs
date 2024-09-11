using go_horse_voos_comerciais.Domain.Passagem;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace go_horse_voos_comerciais.Domain.Reserva
{
    public record DadosListagemReservasDTO (long Id,
                                            long IdCliente,
                                            DateTime DataReserva,
                                            FormaPagamento FormaPagamento,
                                            long IdVoo,
                                            StatusReserva Status,
                                            List<DadosListagemPassagensDTO> passagens)
    {
        public DadosListagemReservasDTO(Reservas reserva) : this (reserva.Id, 
                                                                  reserva.IdCliente, 
                                                                  reserva.DataReserva, 
                                                                  reserva.FormaPagamento, 
                                                                  reserva.IdVoo, 
                                                                  reserva.Status,
                                                                  reserva.Passagens.Select(p => new DadosListagemPassagensDTO(p)).ToList())
        { }
    }
}