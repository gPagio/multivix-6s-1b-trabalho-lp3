namespace go_horse_voos_comerciais.Domain.Cliente;

public record DadosListagemClientesCadastradosDTO(long Id, string? Cpf, string? Nome, string? Endereco, string? TelefoneCelular, string? TelefoneFixo, string? Email)
{
    public DadosListagemClientesCadastradosDTO(Clientes clientes) : this(clientes.Id, clientes.Cpf, clientes.Nome, clientes.Endereco, clientes.TelefoneCelular, clientes.TelefoneFixo, clientes.Email) { }
}
