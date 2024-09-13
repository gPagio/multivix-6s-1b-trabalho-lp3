using go_horse_voos_comerciais.Domain.Local;
using go_horse_voos_comerciais.Domain.Reserva;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/reservas")]
public class ReservaController : Controller
{
    private readonly IReservasService _reservasService;

    public ReservaController(IReservasService reservasService)
    {
        _reservasService = reservasService ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult CadastraReserva(long? idVoo, string cpfCliente, FormaPagamento? formaPagamento, int? quantidadeAssentosDesejados)
    {
        if (!idVoo.HasValue) throw new GhvcValidacaoException("O id do voo é obrigatório para esta ação!");
        if (String.IsNullOrEmpty(cpfCliente)) throw new GhvcValidacaoException("O cpf do cliente é obrigatório para esta ação!");
        if (!formaPagamento.HasValue) throw new GhvcValidacaoException("A forma de pagamento é obrigatória para esta ação!");
        if (!quantidadeAssentosDesejados.HasValue) throw new GhvcValidacaoException("A quantidade de assentos desejados é obrigatória para esta ação!");
        return Ok(_reservasService.CadastraReserva(idVoo, cpfCliente, formaPagamento, quantidadeAssentosDesejados));
    }

    [HttpDelete("{idReserva}")]
    public IActionResult CancelarReserva(long? idReserva)
    {
        if (!idReserva.HasValue) throw new GhvcValidacaoException("O id da reserva é obrigatório para esta operação!");
        _reservasService.CancelaReserva(idReserva);
        return NoContent();
    }

    [HttpGet]
    public IActionResult ListaTodasAsReservas()
    {
        var reservas = _reservasService.ListaReservas();

        return Ok(reservas);
    }
}
