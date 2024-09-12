using go_horse_voos_comerciais.Domain.Reserva;
using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;

namespace go_horse_voos_comerciais.Domain.Relatorios;

public class RelatoriosService : IRelatoriosService
{
    private readonly ApiGhvcDbContext _context;
    private readonly IRepository<Voos> _voosRepository;
    private readonly IRepository<Reservas> _reservasRepository;

    public RelatoriosService(IRepository<Voos> voosRepository, IRepository<Reservas> reservasRepository, ApiGhvcDbContext context)
    {
        _voosRepository = voosRepository;
        _reservasRepository = reservasRepository;
        _context = context;
    }

    public Task<RelatorioOcupacaoDTO> GeraRelatorioOcupacao(DateTime dataInicio, DateTime dataFim)
    {
        if ((dataFim - dataInicio).TotalDays != 7)
        {
            throw new GhvcValidacaoException("O período informado deve ser de exatamente uma semana!");
        }

        Dictionary<long, double> percentuaisDeOcupacao = new();

        var voosNoIntervalo = ObtemVoosNoIntervalo(dataInicio, dataFim);

        foreach (var voo in voosNoIntervalo)
        {
            int totalAssentosOcupados = ObtemTotalPassagens(voo.Id);
            double porcentagemDeOcupacao = totalAssentosOcupados * 100.0 / voo.QuantidadeAssentosTotal;

            percentuaisDeOcupacao.Add(voo.Id, porcentagemDeOcupacao);
        }

        return Task.FromResult(new RelatorioOcupacaoDTO(percentuaisDeOcupacao));
    }

    // Calcula arrecadação por voo baseando-se em passagens vendidas, independentemente do check in
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
            int totalPassagensVendidas = ObtemTotalPassagens(voo.Id);
            double totalArrecadadoNoVoo = totalPassagensVendidas * voo.Preco;
            totaisArrecadadosPorVoo.Add(voo.Id, totalArrecadadoNoVoo);

            var reservasConfirmadas = ObtemReservasConfirmadas(voo.Id);

            foreach (var reserva in reservasConfirmadas)
            {
                int passagensDaReserva = _context.Passagens.Where(passagem => passagem.IdReserva == reserva.Id).Count();
                double valorTotalDaReserva = passagensDaReserva * voo.Preco;

                switch (reserva.FormaPagamento)
                {
                    case FormaPagamento.CARTAO:
                        totalCartao += valorTotalDaReserva;
                        break;
                    case FormaPagamento.TRANSFERENCIA:
                        totalTransferencia += valorTotalDaReserva;
                        break;
                    case FormaPagamento.DINHEIRO:
                        totalDinheiro += valorTotalDaReserva;
                        break;
                }
            }

            totalMesConsultado += totalArrecadadoNoVoo;
        }

        var mesAnterior = mes == 1 ? 12 : mes - 1;
        var anoAnterior = mes == 1 ? ano - 1 : ano;

        var dataInicioMesAnterior = new DateTime(anoAnterior, mesAnterior, 1);
        var dataFimMesAnterior = dataInicioMesAnterior.AddMonths(1).AddDays(-1);

        var voosNoMesAnterior = ObtemVoosNoIntervalo(dataInicioMesAnterior, dataFimMesAnterior);

        foreach (var voo in voosNoMesAnterior)
        {
            int totalPassagensVendidas = ObtemTotalPassagens(voo.Id);
            double totalArrecadadoNoVoo = totalPassagensVendidas * voo.Preco;
            totalMesAnterior += totalArrecadadoNoVoo;
        }

        if (totalMesAnterior > 0)
        {
            percentualDeMudanca = ((totalMesConsultado - totalMesAnterior) / totalMesAnterior) * 100;
        }

        var relatorioVendasDTO = new RelatorioVendasDTO(totaisArrecadadosPorVoo, totalDinheiro, totalCartao, totalTransferencia, totalMesAnterior, totalMesConsultado, percentualDeMudanca);

        return Task.FromResult(relatorioVendasDTO);
    }


    private List<Voos> ObtemVoosNoIntervalo(DateTime? dataInicio, DateTime? dataFim)
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

    private IEnumerable<Reservas> ObtemReservasConfirmadas(long idVoo)
    {
        var reservas = _reservasRepository.GetAll()
                                  .Where(reserva => reserva.IdVoo == idVoo)
                                  .ToList();

        return reservas.Where(reserva => reserva.StatusReserva == StatusReserva.CONFIRMADA);
    }

    private int ObtemTotalPassagens(long idVoo)
    {
        return _context.Passagens
                .FromSql($@"SELECT p.id
                              FROM passagens p
                              JOIN reservas r
                                ON r.id = p.id_reserva
                             WHERE r.id_voo = {idVoo}")
                .Count();
    }
}
