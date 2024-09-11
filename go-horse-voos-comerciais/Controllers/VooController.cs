using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/voos")]
public class VooController : ControllerBase
{
    private readonly IVoosService _voosService;

    public VooController (IVoosService voosService)
    {
        _voosService = voosService;
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaVooPorId (long? id)
    {
        if (!id.HasValue) throw new GhvcValidacaoException("O id do voo � obrigat�rio para essa a��o!");
        return Ok(_voosService.BuscarVooPorId(id));
    }

    [HttpGet]
    public IActionResult ConsultaVooPadrao(long? idOrigem,
                                           long? idDestino,
                                           DateTime? dataIda,
                                           DateTime? dataVolta)
    {
        if (!idOrigem.HasValue) throw new GhvcValidacaoException("O id de origem � obrigat�rio para essa a��o!");
        if (!idDestino.HasValue) throw new GhvcValidacaoException("O id de destino � obrigat�rio para essa a��o!");
        if (!dataIda.HasValue) throw new GhvcValidacaoException("A data de ida � obrigat�ria para essa a��o!");
        return Ok(_voosService.BuscaVooPadrao(idOrigem, idDestino, dataIda, dataVolta));
    }

    [HttpPost]
    public IActionResult CadastrarVoo(DadosCadastroVooDTO dadosCadastroVooDTO)
    {
        return Ok(_voosService.CadastraVoo(dadosCadastroVooDTO));
    }

}