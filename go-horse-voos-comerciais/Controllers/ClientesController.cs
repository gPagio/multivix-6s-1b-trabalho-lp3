using go_horse_voos_comerciais.Domain.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/clientes")]
public class ClientesController : ControllerBase
{
    private readonly IClientesService _clientesService;

    public ClientesController (IClientesService clientesService)
    {
        _clientesService = clientesService ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult CadastraClientes(DadosCadastroClientesDTO dadosCadastroClienteDTO)
    {
        var cliente = _clientesService.CadastraClientes(dadosCadastroClienteDTO);
        return Ok(cliente);
    }

    [HttpGet]
    public IActionResult ListaTodosOsClientes()
    {
        var clientes = _clientesService.ListaClientesCadastradosAsync();
        return Ok(clientes);
    }
}
