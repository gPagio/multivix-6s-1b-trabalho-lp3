using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais.Domain.Cliente;

public class ClientesService : IClientesService
{
    private readonly IRepository<Clientes> _clientesRepository;

    public ClientesService(IRepository<Clientes> clientesRepository)
    {
        _clientesRepository = clientesRepository;
    }

    public Task<DadosListagemClientesCadastradosDTO> CadastraClientes(DadosCadastroClientesDTO dadosCadastroClientesDTO)
    {
        if (_clientesRepository.ExistsBy(clientes => clientes.Cpf.Trim() == dadosCadastroClientesDTO.Cpf.Trim()))
        {
            throw new GhvcValidacaoException("Já existe um cliente com o CPF informado!");
        }

        var clientes = new Clientes(dadosCadastroClientesDTO);
        _clientesRepository.Add(clientes);

        return Task.FromResult(new DadosListagemClientesCadastradosDTO(clientes));
    }

    public async Task<IEnumerable<DadosListagemClientesCadastradosDTO>> ListaClientesCadastradosAsync()
    {
        var clientesCadastrados = _clientesRepository.GetAll();

        var clientesDTOs = clientesCadastrados
            .Select(clientesCadastrados => new DadosListagemClientesCadastradosDTO(clientesCadastrados))
            .ToList();

        return await Task.FromResult(clientesDTOs);
    }

    public Task<DadosCadastroClientesDTO> BuscaClientePorCpf(string cpf)
    {
        if (_clientesRepository.ExistsBy(cliente => cliente.Cpf.Trim() == cpf))
        {
            var cliente = _clientesRepository.GetAll().FirstOrDefault(c => c.Cpf.Trim() == cpf.Trim());

            if (cliente != null)
            {
                var clienteDTO = new DadosCadastroClientesDTO(cliente.Cpf, cliente.Nome, cliente.Endereco, cliente.TelefoneCelular, cliente.TelefoneFixo, cliente.Email);
                return Task.FromResult(clienteDTO);
            }
        }

        throw new Exception("Cliente não encontrado");
    }
}
