using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

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

    public CompanhiasOperantes() { }

    public CompanhiasOperantes(DadosCadastroCompanhiasOperantesDTO dadosCadastroCompanhiasOperantes)
    {
        this.Cnpj = dadosCadastroCompanhiasOperantes.Cnpj.Trim();
        this.Nome = dadosCadastroCompanhiasOperantes.Nome.Trim();
    }
}