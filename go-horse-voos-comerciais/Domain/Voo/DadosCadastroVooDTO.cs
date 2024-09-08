using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Voo;

public record DadosCadastroVooDTO ([NotNull] long IdOrigem,
                                   [NotNull] long IdDestino,
                                   [NotNull] DateTime DataIda,
                                   [NotNull] DateTime DataVolta,
                                   [NotNull] long IdCompanhiaOperante,
                                   [NotNull] double Preco,
                                   [NotNull] int QuantidadeAssentos) { }