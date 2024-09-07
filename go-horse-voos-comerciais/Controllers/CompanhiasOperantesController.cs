using go_horse_voos_comerciais.Domain.CompanhiaOperante;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers
{
    [ApiController]
    [Route("/companhias-operantes")]
    public class CompanhiasOperantesController : ControllerBase
    {
        private readonly ICompanhiasOperantesService _companhiasOperantesService;

        public CompanhiasOperantesController(ICompanhiasOperantesService companhiasOperantesService)
        {
            _companhiasOperantesService = companhiasOperantesService ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult CadastraCompanhiasOperantes(DadosCadastroCompanhiasOperantesDTO dadosCadastroCompanhiasOperantesDTO)
        {
            var companhia = _companhiasOperantesService.CadastraCompanhiasOperantes(dadosCadastroCompanhiasOperantesDTO);
            return Ok(companhia);
        }

        [HttpGet]
        public IActionResult ListaTodasAsCompanhiasOperantes() 
        {
            var companhias = _companhiasOperantesService.ListaCompanhiasOperantesCadastradasAsync();
            return Ok(companhias);
        }
    }
}
