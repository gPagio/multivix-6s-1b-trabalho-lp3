using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Local;

public record DadosCadastroLocaisDTO([Required(ErrorMessage = "O campo nome é obrigatório!")]
                                     string Nome);
