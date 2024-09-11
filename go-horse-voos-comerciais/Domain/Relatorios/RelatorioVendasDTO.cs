using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Relatorios;

// TotaisArrecadadosPorVoo armazena o par IdVoo e o valor total de vendas (reservas confirmadas * valor de venda)
public record RelatorioVendasDTO([NotNull] Dictionary<long, double>? TotaisArrecadadosPorVoo, [NotNull] double TotalDinheiro, 
    [NotNull] double TotalCartao, [NotNull] double TotalTransferencia, [NotNull] double TotalMesAnterior, 
    [NotNull] double TotalMesConsultado, [NotNull] double PercentualDeMudanca);
