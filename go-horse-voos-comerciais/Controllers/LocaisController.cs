using go_horse_voos_comerciais.Domain.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Controllers
{
    [ApiController]
    [Route("/locais")]
    public class LocaisController : ControllerBase
    {
        private readonly ILocaisRepository _locaisRepository;

        public LocaisController(ILocaisRepository locaisRepository)
        {
            _locaisRepository = locaisRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult CadastrarLocais(DadosCadastroLocaisDTO dadosCadastroLocais)
        {
            Locais local = new Locais(dadosCadastroLocais);
            _locaisRepository.Add(local);
            return Ok(new DadosListagemLocaisCadastradoDTO(local));
        }

        [HttpGet]
        public IActionResult ListarTodosOsLocais()
        {
            var locais = _locaisRepository.GetAll();
            return Ok(locais);
        }
    }
}
