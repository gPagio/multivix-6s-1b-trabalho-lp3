namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public record DadosListagemCompanhiasOperantesCadastradasDTO(long Id, string? Cnpj, string? Nome)
{
    public DadosListagemCompanhiasOperantesCadastradasDTO(CompanhiasOperantes companhias) : this (companhias.Id, companhias.Cnpj, companhias.Nome) {}
};
