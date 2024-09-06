using FluentValidation;
using go_horse_voos_comerciais.Domain.CompanhiaOperante;
using System.Text.RegularExpressions;

namespace go_horse_voos_comerciais.Validators;

public class CompanhiaOperanteValidator : AbstractValidator<DadosCadastroCompanhiasOperantesDTO>
{
    public CompanhiaOperanteValidator()
    {
        RuleFor(companhia => companhia.Cnpj)
            .NotEmpty().WithMessage("O campo CNPJ é obrigatório.")
            .Must(CnpjEValido).WithMessage("O CNPJ informado é inválido.");
    }

    private bool CnpjEValido(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, @"[^\d]", "");

        if (cnpj.Length != 14) { return false; }

        return true;
    }
}
