using go_horse_voos_comerciais.Domain.Local;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("locais")]
public class Locais
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; private set; }

    [Column("nome")]
    public string? Nome { get; private set; }

    public Locais()
    {

    }

    public Locais(DadosCadastroLocaisDTO dadosCadastroLocais)
    {
        this.Nome = dadosCadastroLocais.Nome.Trim();
    }
}