using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Cliente;

public record DadosCadastroClientesDTO([Required(ErrorMessage = "O campo CPF é obrigatório!")]
                                       string? Cpf,

                                       [Required(ErrorMessage = "O campo nome é obrigatório!")]
                                       string? Nome,

                                       [Required(ErrorMessage = "O campo endereço é obrigatório!")]
                                       string? Endereco,

                                       [Required(ErrorMessage = "O campo telefone celular é obrigatório!")]
                                       string? TelefoneCelular,

                                       [Required(ErrorMessage = "O campo telefone fixo é obrigatório!")]
                                       string? TelefoneFixo,

                                       [Required(ErrorMessage = "O campo email é obrigatório!")]
                                       [EmailAddress(ErrorMessage = "O email deve possuir o formato email@email.com")]
                                       string? Email);

