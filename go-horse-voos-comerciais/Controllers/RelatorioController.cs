using go_horse_voos_comerciais.Domain.Relatorios;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
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

    [HttpGet("ocupacao")]
    public IActionResult ConsultaRelatorioOcupacao (DateTime? dataInicio, DateTime? dataFim)
    {
        if (!dataInicio.HasValue) throw new GhvcValidacaoException("Data inicial é obrigatória para esta ação!");
        if (!dataFim.HasValue) throw new GhvcValidacaoException("Data final é obrigatória para esta ação!");
        var relatorioOcupacaoDTO = _relatoriosService.GeraRelatorioOcupacao(dataInicio, dataFim);
        string jsonString = JsonSerializer.Serialize(relatorioOcupacaoDTO);
        return Ok(jsonString);
    }

    [HttpGet("vendas")]
    public IActionResult ConsultaRelatorioVendas(int? mes, int? ano)
    {
        if (!mes.HasValue) throw new GhvcValidacaoException("O mês é obrigatório para esta ação!");
        if (!ano.HasValue) throw new GhvcValidacaoException("O ano é obrigatório para esta ação!");
        var relatorioVendasDTO = _relatoriosService.GeraRelatorioVendas(mes, ano);
        string jsonString = JsonSerializer.Serialize(relatorioVendasDTO);
        return Ok(jsonString);
    }
}
