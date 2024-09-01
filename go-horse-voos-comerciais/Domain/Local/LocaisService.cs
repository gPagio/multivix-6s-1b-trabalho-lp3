﻿
namespace go_horse_voos_comerciais.Domain.Local
{
    public class LocaisService : ILocaisService
    {

        private readonly ILocaisRepository _locaisRepository;

        public LocaisService(ILocaisRepository locaisRepository)
        {
            _locaisRepository = locaisRepository ?? throw new ArgumentNullException();
        }
        public Task<DadosListagemLocaisCadastradoDTO> CadastraLocais(DadosCadastroLocaisDTO dadosCadastroLocaisDTO)
        {
            if (_locaisRepository.ExistsByNomeIgnoreCase(dadosCadastroLocaisDTO.Nome)) throw new Exception("Já existe um local com o nome  informado!");
            var locais = new Locais(dadosCadastroLocaisDTO);
            _locaisRepository.Add(locais);
            return Task.FromResult(new DadosListagemLocaisCadastradoDTO(locais));
        }

        public async Task<IEnumerable<DadosListagemLocaisCadastradoDTO>> ListaLocaisCadastradosAsync()
        {
            var locaisCadastrados = _locaisRepository.GetAll();

            var locaisDTOs = locaisCadastrados
                .Select(local => new DadosListagemLocaisCadastradoDTO(local))
                .ToList();

            return await Task.FromResult(locaisDTOs);
        }
    }
}