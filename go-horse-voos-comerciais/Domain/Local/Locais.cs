using go_horse_voos_comerciais.Domain.Voo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace go_horse_voos_comerciais.Domain.Local;

[Table("locais")]
public class Locais
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; private set; }

    [Column("nome")]
    public string? Nome { get; private set; }

    public ICollection<Voos> VoosOrigem { get; set; }

    public ICollection<Voos> VoosDestino { get; set; }

    public Locais() { }

    public Locais(DadosCadastroLocaisDTO dadosCadastroLocais)
    {
        this.Nome = dadosCadastroLocais.Nome.Trim();
    }
}