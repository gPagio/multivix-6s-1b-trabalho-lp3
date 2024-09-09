
using go_horse_voos_comerciais.Domain.Reserva;
using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais.Domain.Relatorios;

public class RelatoriosService : IRelatoriosService
{
    private readonly IRepository<Voos> _voosRepository;
    private readonly IRepository<Reservas> _reservasRepository;

    public RelatoriosService(IRepository<Voos> voosRepository, IRepository<Reservas> reservasRepository)
    {
        _voosRepository = voosRepository;
        _reservasRepository = reservasRepository;
    }

    // Aguardar a criação de reservas no banco de dados
    public Task<RelatorioOcupacaoDTO> GeraRelatorioOcupacao(DateTime dataInicio, DateTime dataFim)
    {
        RelatorioOcupacaoDTO relatorioOcupacaoDTO = new();

        var voosNoIntervalo = _voosRepository.GetAll().Where(voo => voo.DataIda >= dataInicio
                                                                 && voo.DataVolta <= dataFim);

        if (voosNoIntervalo.Count() == 0) throw new GhvcValidacaoException("Não existem voos no período informado!");

        foreach (var voo in voosNoIntervalo) 
        {
            var reservasDoVoo = _reservasRepository.GetAll()
                                                   .Where(reserva => reserva.IdVoo == voo.Id)
                                                   .ToList();

            int totalReservasConfirmadas = reservasDoVoo.Count(reserva => reserva.Status == StatusReserva.CONFIRMADA);
            double porcentagemDeOcupacao = totalReservasConfirmadas * 100.0 / voo.QuantidadeAssentos;

            relatorioOcupacaoDTO.PercentuaisDeOcupacao.Add(voo, porcentagemDeOcupacao);
        }

        return Task.FromResult(relatorioOcupacaoDTO);
    }
}
