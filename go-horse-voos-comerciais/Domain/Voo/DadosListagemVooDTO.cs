using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Voo;

public record DadosListagemVooDTO(
    [NotNull] long id,
    [NotNull] long IdOrigem,
    [NotNull] long IdDestino,
    [NotNull] DateTime DataIda,
    [NotNull] DateTime DataVolta,
    [NotNull] long IdCompanhiaOperante,
    [NotNull] double Preco,
    [NotNull] int QuantidadeAssentos) {

    public DadosListagemVooDTO (Voo voo) : this (voo.Id, voo.IdOrigem, voo.IdDestino, voo.DataIda, voo.DataVolta, voo.IdCompanhiaOperante, voo.Preco, voo.QuantidadeAssentos ) 
    {
    }

}