using System.Diagnostics.CodeAnalysis;

namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public record DadosCadastroCompanhiasOperantesDTO([NotNull] string Cnpj, [NotNull] string Nome);

