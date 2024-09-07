﻿namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public interface ICompanhiasOperantesService
{
    Task<DadosListagemCompanhiasOperantesCadastradasDTO> CadastraCompanhiasOperantes(DadosCadastroCompanhiasOperantesDTO dadosCadastroCompanhiasOperantesDTO);
    Task<IEnumerable<DadosListagemCompanhiasOperantesCadastradasDTO>> ListaCompanhiasOperantesCadastradasAsync();
}
