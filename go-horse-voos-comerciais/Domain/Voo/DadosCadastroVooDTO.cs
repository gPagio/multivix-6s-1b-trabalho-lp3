using System.ComponentModel.DataAnnotations;

namespace go_horse_voos_comerciais.Domain.Voo;

public record DadosCadastroVooDTO ([Required(ErrorMessage = "O campo id origem é obrigatório!")] long IdOrigem,
                                   [Required(ErrorMessage = "O campo id destino é obrigatório!")] long IdDestino,
                                   [Required(ErrorMessage = "O campo data ida é obrigatório!")] DateTime DataIda,
                                   [Required(ErrorMessage = "O campo data volta é obrigatório!")] DateTime DataVolta,
                                   [Required(ErrorMessage = "O campo id companhia operante é obrigatório!")] long IdCompanhiaOperante,
                                   [Required(ErrorMessage = "O campo preço é obrigatório!")] double Preco,
                                   [Required(ErrorMessage = "O campo quantidade de assentos é obrigatório!")] int QuantidadeAssentosTotal) { }