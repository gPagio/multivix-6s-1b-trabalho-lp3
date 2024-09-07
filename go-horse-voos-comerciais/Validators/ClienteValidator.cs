using FluentValidation;
using go_horse_voos_comerciais.Domain.Cliente;
using System.Text.RegularExpressions;

namespace go_horse_voos_comerciais.Validators;

public class ClienteValidator : AbstractValidator<DadosCadastroClientesDTO>
{
    public ClienteValidator()
    {
        RuleFor(cliente => cliente.Cpf)
            .NotEmpty().WithMessage("O campo CPF é obrigatório.")
            .Must(CpfEValido).WithMessage("O CPF informado é inválido.");

        RuleFor(cliente => cliente.Email)
            .EmailAddress().WithMessage("O email informado é inválido.");
    }

    private bool CpfEValido(string cpf)
    {
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        if (cpf.Length != 11) { return false; }

        return true;
    }
}
