
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
        Dictionary<Voos, double> percentuaisDeOcupacao = new();

        var voosNoIntervalo = ObtemVoosNoIntervalo(dataInicio, dataFim);

        foreach (var voo in voosNoIntervalo) 
        {
            int totalReservasConfirmadas = ObtemTotalReservasConfirmadas(voo);
            double porcentagemDeOcupacao = totalReservasConfirmadas * 100.0 / voo.QuantidadeAssentos;

            percentuaisDeOcupacao.Add(voo, porcentagemDeOcupacao);
        }

        return Task.FromResult(new RelatorioOcupacaoDTO(percentuaisDeOcupacao));
    }

    public Task<RelatorioVendasDTO> GeraRelatorioVendas(int mes, int ano)
    {
        Dictionary<long, double> totaisArrecadadosPorVoo = new();
        double totalDinheiro = 0;
        double totalCartao = 0;
        double totalTransferencia = 0;
        double totalMesAnterior = 0;
        double totalMesConsultado = 0;
        double percentualDeMudanca = 0;

        var dataInicio = new DateTime(ano, mes, 1);
        var dataFim = dataInicio.AddMonths(1).AddDays(-1);

        var voosNoIntervalo = ObtemVoosNoIntervalo(dataInicio, dataFim);

        foreach (var voo in voosNoIntervalo)
        {
            int totalReservasConfirmadas = ObtemTotalReservasConfirmadas(voo);
            double totalArrecadado = totalReservasConfirmadas * voo.Preco;
            totaisArrecadadosPorVoo.Add(voo.Id, totalArrecadado);

            var reservasConfirmadas = ObtemReservasDoVoo(voo);
            totalDinheiro += reservasConfirmadas.Where(reserva => reserva.FormaPagamento == FormaPagamento.DINHEIRO).Sum(reserva => voo.Preco);
            totalCartao += reservasConfirmadas.Where(reserva => reserva.FormaPagamento == FormaPagamento.CARTAO).Sum(reserva => voo.Preco);
            totalTransferencia += reservasConfirmadas.Where(reserva => reserva.FormaPagamento == FormaPagamento.TRANSFERENCIA).Sum(reserva => voo.Preco);

            totalMesConsultado += totalArrecadado;           
        }

        // Arrecadação do mês anterior
        var mesAnterior = mes == 1 ? 12 : mes - 1;
        var anoAnterior = mes == 1 ? ano - 1 : ano;

        var dataInicioMesAnterior = new DateTime(anoAnterior, mesAnterior, 1);
        var dataFimMesAnterior = dataInicioMesAnterior.AddMonths(1).AddDays(-1);

        var voosNoMesAnterior = ObtemVoosNoIntervalo(dataInicioMesAnterior, dataFimMesAnterior);

        foreach (var voo in voosNoMesAnterior)
        {
            int totalReservasConfirmadasMesAnterior = ObtemTotalReservasConfirmadas(voo);
            double totalArrecadadoMesAnterior = totalReservasConfirmadasMesAnterior * voo.Preco;
            totalMesAnterior += totalArrecadadoMesAnterior;
        }

        if (totalMesAnterior > 0)
        {
            percentualDeMudanca = ((totalMesConsultado - totalMesAnterior) / totalMesAnterior) * 100;
        }

        var relatorioVendasDTO = new RelatorioVendasDTO(totaisArrecadadosPorVoo, totalDinheiro, totalCartao, totalTransferencia, totalMesAnterior, totalMesConsultado, percentualDeMudanca);

        return Task.FromResult(relatorioVendasDTO);
    }


    private List<Voos> ObtemVoosNoIntervalo(DateTime dataInicio, DateTime dataFim)
    {
        var voosNoIntervalo = _voosRepository.GetAll()
                                             .Where(voo => voo.DataIda >= dataInicio && voo.DataVolta <= dataFim)
                                             .ToList();

        if (!voosNoIntervalo.Any())
        {
            throw new GhvcValidacaoException("Não existem voos no período informado!");
        }

        return voosNoIntervalo;
    }

    private int ObtemTotalReservasConfirmadas(Voos voo)
    {
        return ObtemReservasDoVoo(voo).Count(reserva => reserva.Status == StatusReserva.CONFIRMADA);
    }

    private List<Reservas> ObtemReservasDoVoo(Voos voo)
    {
        return _reservasRepository.GetAll()
                                  .Where(reserva => reserva.IdVoo == voo.Id)
                                  .ToList();
    }
}
