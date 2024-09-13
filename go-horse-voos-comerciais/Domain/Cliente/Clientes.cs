using go_horse_voos_comerciais.Domain.Reserva;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace go_horse_voos_comerciais.Domain.Cliente;

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
    
    [Column("telefone_celular")]
    public string? TelefoneCelular { get; set; }
    
    [Column("telefone_fixo")]
    public string? TelefoneFixo { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }

    public ICollection<Reservas> Reservas { get; set; }

    public Clientes() { }

    public Clientes(DadosCadastroClientesDTO dadosCadastroClientesDTO)
    {
        this.Cpf = dadosCadastroClientesDTO.Cpf.Trim();
        this.Nome = dadosCadastroClientesDTO.Nome.Trim();
        this.Endereco = dadosCadastroClientesDTO.Endereco.Trim();
        this.TelefoneCelular = dadosCadastroClientesDTO.TelefoneCelular.Trim();
        this.TelefoneFixo = dadosCadastroClientesDTO.TelefoneFixo.Trim();
        this.Email = dadosCadastroClientesDTO.Email.Trim();
    }
}