using go_horse_voos_comerciais.Domain.Local;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/locais")]
public class LocaisController : ControllerBase
{
    private readonly ILocaisService _locaisService;

    public LocaisController(ILocaisService locaisService)
    {
        _locaisService = locaisService ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult CadastrarLocais(DadosCadastroLocaisDTO dadosCadastroLocais)
    {
        var local = _locaisService.CadastraLocais(dadosCadastroLocais);
        return Ok(local);
    }

    [HttpGet]
    public IActionResult ListarTodosOsLocais()
    {
        var locais = _locaisService.ListaLocaisCadastradosAsync();
        return Ok(locais);
    }
}
