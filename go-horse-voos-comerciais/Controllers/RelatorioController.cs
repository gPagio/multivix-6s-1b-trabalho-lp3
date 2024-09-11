using go_horse_voos_comerciais.Domain.Relatorios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/relatorios")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatoriosService _relatoriosService;

    public RelatorioController (IRelatoriosService relatoriosService)
    {
        _relatoriosService = relatoriosService;
    }

    // TODO: armazenar o json 
    [HttpGet("ocupacao")]
    public IActionResult ConsultaRelatorioOcupacao (DateTime dataInicio, DateTime dataFim)
    {
        var relatorioOcupacaoDTO = _relatoriosService.GeraRelatorioOcupacao(dataInicio, dataFim);
        string jsonString = JsonSerializer.Serialize(relatorioOcupacaoDTO);
        return Ok(jsonString);
    }

    [HttpGet("vendas")]
    public IActionResult ConsultaRelatorioVendas(int mes, int ano)
    {
        var relatorioVendasDTO = _relatoriosService.GeraRelatorioVendas(mes, ano);
        string jsonString = JsonSerializer.Serialize(relatorioVendasDTO);
        return Ok(jsonString);
    }
}
