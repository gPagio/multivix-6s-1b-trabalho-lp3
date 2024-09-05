using go_horse_voos_comerciais.Domain.Cliente;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("clientes")]
public class Clientes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    [Column("cpf")]
    public string? Cpf { get; set; }
    [Column("nome")]
    public string? Nome { get; set; }
    [Column("endereco")]
    public string? Endereco { get; set; }
    [Column("telefoneCelular")]
    public string? TelefoneCelular { get; set; }
    [Column("telefoneFixo")]
    public string? TelefoneFixo { get; set; }
    [Column("email")]
    public string? Email { get; set; }

    public Clientes()
    {

    }

    public Clientes(DadosCadastroClientesDTO dadosCadastroClientesDTO)
    {
        this.Cpf = dadosCadastroClientesDTO.Cpf;
        this.Nome = dadosCadastroClientesDTO.Nome;
        this.Endereco = dadosCadastroClientesDTO.Endereco;
        this.TelefoneCelular = dadosCadastroClientesDTO.TelefoneCelular;
        this.TelefoneFixo = dadosCadastroClientesDTO.TelefoneFixo;
        this.Email = dadosCadastroClientesDTO.Email;
    }
}