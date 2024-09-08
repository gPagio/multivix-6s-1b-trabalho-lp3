using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Voo;

public record DadosPesquisaVooDTO([NotNull] long IdOrigem,
                                   [NotNull] long IdDestino,
                                   [NotNull] DateTime DataIda,
                                   DateTime? DataVolta) { }