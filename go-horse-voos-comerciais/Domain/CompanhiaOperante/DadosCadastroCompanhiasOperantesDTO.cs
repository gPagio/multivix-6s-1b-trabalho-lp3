using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public record DadosCadastroCompanhiasOperantesDTO([Required(ErrorMessage = "O campo CNPJ é obrigatório!")]
                                                  string Cnpj,

                                                  [Required(ErrorMessage = "O campo nome é obrigatório!")]
                                                  string Nome);