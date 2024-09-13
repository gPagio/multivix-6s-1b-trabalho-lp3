using go_horse_voos_comerciais.Domain.Passagem;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/passagens")]
public class PassagemController : ControllerBase
{
    private readonly IPassagensService _passagensService;
    public PassagemController(IPassagensService passagensService)
    {
        _passagensService = passagensService;
    }

    [HttpPut]
    public IActionResult RealizarCheckIn(long? idPassagem, int? numeroAssentoDesejado)
    {
        if (!idPassagem.HasValue) throw new GhvcValidacaoException("O id da passagem é obrigatório para essa operação!");
        if (!numeroAssentoDesejado.HasValue) throw new GhvcValidacaoException("O número do assento é obrigatório para essa operação!");
        var bilhete = _passagensService.RealizarCheckIn(idPassagem.Value, numeroAssentoDesejado.Value);
        return Ok(bilhete);
    }
}
