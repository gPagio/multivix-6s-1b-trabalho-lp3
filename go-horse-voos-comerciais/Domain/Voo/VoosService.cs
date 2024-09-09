using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;
using go_horse_voos_comerciais.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace go_horse_voos_comerciais.Domain.Voo;

public class VoosService : IVoosService
{
    private readonly IRepository<Voos> _voosRepository;
    private readonly IRepository<Locais> _locaisRepository;
    private readonly IRepository<CompanhiasOperantes> _companhiasOperanteRepository;

    public VoosService(IRepository<Voos> voosRepository, IRepository<Locais> locaisRepository, IRepository<CompanhiasOperantes> companhiasOperanteRepository)
    {
        _voosRepository = voosRepository;
        _locaisRepository = locaisRepository;
        _companhiasOperanteRepository = companhiasOperanteRepository;
    }

    public Task<DadosListagemVooDTO> CadastraVoo(DadosCadastroVooDTO dadosCadastroVooDTO)
    {
        if (dadosCadastroVooDTO.DataIda < DateTime.Now) throw new GhvcValidacaoException("A data de ida não pode ser menor que a data atual!");
        if (dadosCadastroVooDTO.DataIda >= dadosCadastroVooDTO.DataVolta) throw new GhvcValidacaoException("A data de volta não pode ser menor ou igual a data de ida!");
        if (dadosCadastroVooDTO.IdOrigem == dadosCadastroVooDTO.IdDestino) throw new GhvcValidacaoException("O local de destino do voo deve ser diferente do local de origem!");
        if (dadosCadastroVooDTO.Preco == 0) throw new GhvcValidacaoException("O preço não pode ser igual a zero!");
        if (dadosCadastroVooDTO.QuantidadeAssentos == 0) throw new GhvcValidacaoException("A quantidade de assentos não pode ser igual a zero!");

        if (!_locaisRepository.ExistsBy(local => local.Id.Equals(dadosCadastroVooDTO.IdOrigem))) throw new GhvcValidacaoException("Não existe um local cadastrado correspondente a origem informada!");
        if (!_locaisRepository.ExistsBy(local => local.Id.Equals(dadosCadastroVooDTO.IdDestino))) throw new GhvcValidacaoException("Não existe um local cadastrado correspondente ao destino informado!");
        if (!_companhiasOperanteRepository.ExistsBy(co => co.Id.Equals(dadosCadastroVooDTO.IdCompanhiaOperante))) throw new GhvcValidacaoException("Não existe uma companhia operante correspondente a informada!");

        IQueryable<Voos> queryVooIdenticoMesmoDia = _voosRepository.GetAll().AsQueryable();
        queryVooIdenticoMesmoDia = queryVooIdenticoMesmoDia.Where(voo => voo.IdOrigem.Equals(dadosCadastroVooDTO.IdOrigem)
                                                                      && voo.IdDestino.Equals(dadosCadastroVooDTO.IdDestino)
                                                                      && voo.DataIda.Year.Equals(dadosCadastroVooDTO.DataIda.Year)
                                                                      && voo.DataIda.Month.Equals(dadosCadastroVooDTO.DataIda.Month)
                                                                      && voo.DataIda.Day.Equals(dadosCadastroVooDTO.DataIda.Day)
                                                                      && voo.IdCompanhiaOperante.Equals(dadosCadastroVooDTO.IdCompanhiaOperante));

        if (!(queryVooIdenticoMesmoDia.ToList().Count == 0)) throw new GhvcValidacaoException("Já existe um voo com mesma origem e destino para a companhia e data de ida informada!");

        Voos vooCadastrado = new Voos(dadosCadastroVooDTO);
        _voosRepository.Add(vooCadastrado);
        return Task.FromResult(new DadosListagemVooDTO(vooCadastrado));
    }

    public Task<DadosListagemVooDTO> BuscarVooPorId(long id)
    {
        if (!_voosRepository.ExistsBy(voo => voo.Id == id)) throw new GhvcValidacaoException("Nenhum voo encontrado com o ID informado!");
        return Task.FromResult(new DadosListagemVooDTO(_voosRepository.GetById(id)));
    }

    public Task<List<DadosListagemVooDTO>> BuscaVooPadrao(long idOrigem, long idDestino, DateTime dataIda, DateTime? dataVolta)
    {
        IQueryable<Voos> query = _voosRepository.GetAll().AsQueryable();
        query = query.Where(voo => voo.IdDestino.Equals(idDestino)
                                && voo.IdOrigem.Equals(idOrigem)
                                && voo.DataIda.Date.Equals(dataIda));

        if (dataVolta != null)
        {
            query = query.Where(voo => voo.DataVolta.Date.Equals(dataVolta));
        }

        List<DadosListagemVooDTO> vooEncontrado = query.Select(voo => new DadosListagemVooDTO(voo)).ToList();

        if (vooEncontrado.Count == 0) throw new GhvcValidacaoException("Nenhum voo encontrado com os critérios fornecidos!");

        return Task.FromResult(vooEncontrado);
    }


}