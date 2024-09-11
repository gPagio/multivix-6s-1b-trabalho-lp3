namespace go_horse_voos_comerciais.Domain.Voo;

public interface IVoosService
{
    Task<DadosListagemVooDTO> CadastraVoo(DadosCadastroVooDTO dadosCadastroVooDTO);
    Task<DadosListagemVooDTO> BuscarVooPorId (long? id);
    Task<List<DadosListagemVooDTO>> BuscaVooPadrao (long? idOrigem, long? idDestino, DateTime? dataIda, DateTime? dataVolta);
}