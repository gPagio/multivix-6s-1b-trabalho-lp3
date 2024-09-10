using go_horse_voos_comerciais.Domain.Reserva;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers;

[ApiController]
[Route("/reservas")]
public class ReservaController : Controller
{
    private readonly IReservasService _reservasService;

    public ReservaController(IReservasService reservasService)
    {
        _reservasService = reservasService;
    }
    
    public IActionResult CadastraReserva()
    {
        
        return null;
    }
}
