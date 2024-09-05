namespace go_horse_voos_comerciais.Domain.Cliente;

public interface IClientesService
{
    Task<DadosListagemClientesCadastradosDTO> CadastraClientes(DadosCadastroClientesDTO dadosCadastroClientesDTO);
    Task<IEnumerable<DadosListagemClientesCadastradosDTO>> ListaClientesCadastradosAsync();
}
