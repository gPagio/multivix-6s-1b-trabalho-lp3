namespace go_horse_voos_comerciais.Domain.Local
{
    public interface ILocaisService
    {
        Task<DadosListagemLocaisCadastradoDTO> CadastraLocais (DadosCadastroLocaisDTO dadosCadastroLocaisDTO);
        Task<IEnumerable<DadosListagemLocaisCadastradoDTO>> ListaLocaisCadastradosAsync();
    }
}
