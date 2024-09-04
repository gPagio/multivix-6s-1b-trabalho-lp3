using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public class CompanhiasOperantesService : ICompanhiasOperantesService
{
    private readonly IRepository<CompanhiasOperantes> _companhiasOperantesRepository;

    public CompanhiasOperantesService(IRepository<CompanhiasOperantes> companhiasOperantesRepository)
    {
        _companhiasOperantesRepository = companhiasOperantesRepository;
    }

    public Task<DadosListagemCompanhiasOperantesCadastradasDTO> CadastraCompanhiasOperantes(DadosCadastroCompanhiasOperantesDTO dadosCadastroCompanhiasOperantesDTO)
    {
        if (_companhiasOperantesRepository.ExistsBy(companhiaOperante => companhiaOperante.Nome.ToLower().Trim() == dadosCadastroCompanhiasOperantesDTO.Nome.ToLower().Trim()))
        {
            throw new GhvcValidacaoException("Já existe uma companhia com o nome informado!");
        }

        var companhiasOperantes = new CompanhiasOperantes(dadosCadastroCompanhiasOperantesDTO);
        _companhiasOperantesRepository.Add(companhiasOperantes);

        return Task.FromResult(new DadosListagemCompanhiasOperantesCadastradasDTO(companhiasOperantes));
    }

    public async Task<IEnumerable<DadosListagemCompanhiasOperantesCadastradasDTO>> ListaCompanhiasOperantesCadastradasAsync()
    {
        var companhiasOperantesCadastradas = _companhiasOperantesRepository.GetAll();

        var companhiasOperantesDTOs = companhiasOperantesCadastradas
            .Select(companhiasoperantes => new DadosListagemCompanhiasOperantesCadastradasDTO(companhiasoperantes))
            .ToList();

        return await Task.FromResult(companhiasOperantesDTOs);
    }
}
