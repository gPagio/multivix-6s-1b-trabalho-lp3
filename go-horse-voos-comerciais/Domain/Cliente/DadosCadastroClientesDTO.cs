using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.Cliente;

public record DadosCadastroClientesDTO([NotNull]
                                       string? Cpf,
                                       
                                       [NotNull] 
                                       string? Nome, 
                                       
                                       [NotNull] 
                                       string? Endereco, 
                                       
                                       [NotNull] 
                                       string? TelefoneCelular, 
                                       
                                       [NotNull] 
                                       string? TelefoneFixo, 
                                       
                                       [EmailAddress(ErrorMessage = "O email deve possuir o formato email@email.com")]
                                       string? Email);

