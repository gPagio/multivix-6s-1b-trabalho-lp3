namespace go_horse_voos_comerciais.Domain.Local;

public record DadosListagemLocaisCadastradoDTO (long Id, string? Nome)
{
    public DadosListagemLocaisCadastradoDTO(Locais locais) : this (locais.Id, locais.Nome) {}
};
