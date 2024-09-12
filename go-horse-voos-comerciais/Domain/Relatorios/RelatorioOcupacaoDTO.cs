using go_horse_voos_comerciais.Domain.Voo;
using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Relatorios;

public record RelatorioOcupacaoDTO([NotNull] Dictionary<long, double>? PercentuaisDeOcupacao);
