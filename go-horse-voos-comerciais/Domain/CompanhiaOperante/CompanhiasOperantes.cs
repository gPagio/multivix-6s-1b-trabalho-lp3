using go_horse_voos_comerciais.Domain.CompanhiaOperante;
using go_horse_voos_comerciais.Domain.Local;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CompanhiasOperantes")]
public class CompanhiasOperantes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("cnpj")]
    public string? Cnpj { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    public CompanhiasOperantes()
    {

    }

    public CompanhiasOperantes(DadosCadastroCompanhiasOperantesDTO dadosCadastroCompanhiasOperantes)
    {
        this.Cnpj = dadosCadastroCompanhiasOperantes.Cnpj;
        this.Nome = dadosCadastroCompanhiasOperantes.Nome.Trim();
    }
}