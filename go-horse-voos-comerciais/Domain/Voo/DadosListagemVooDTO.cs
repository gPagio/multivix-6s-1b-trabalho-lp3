using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Voo;

public record DadosListagemVooDTO(
    long id,
    long IdOrigem,
    long IdDestino,
    DateTime DataIda,
    DateTime DataVolta,
    long IdCompanhiaOperante,
    double Preco,
    int QuantidadeAssentos) {


    public DadosListagemVooDTO (Voos voo) : this (voo.Id,
                                                  voo.IdOrigem,
                                                  voo.IdDestino,
                                                  voo.DataIda,
                                                  voo.DataVolta,
                                                  voo.IdCompanhiaOperante,
                                                  voo.Preco,
                                                  voo.QuantidadeAssentosTotal ) { }
}