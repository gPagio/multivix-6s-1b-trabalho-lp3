using go_horse_voos_comerciais.Domain.Voo;
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
    public IActionResult ConsultaVooPorId (long id)
    {
        return Ok(_voosService.BuscarVooPorId(id));
    }

    [HttpGet]
    public IActionResult ConsultaVooPadrao([FromQuery] long idOrigem,
                                           [FromQuery] long idDestino,
                                           [FromQuery] DateTime dataIda,
                                           [FromQuery] DateTime? dataVolta)
    {
        return Ok(_voosService.BuscaVooPadrao(idOrigem, idDestino, dataIda, dataVolta));
    }

    [HttpPost]
    public IActionResult CadastrarVoo(DadosCadastroVooDTO dadosCadastroVooDTO)
    {
        return Ok(_voosService.CadastraVoo(dadosCadastroVooDTO));
    }

}