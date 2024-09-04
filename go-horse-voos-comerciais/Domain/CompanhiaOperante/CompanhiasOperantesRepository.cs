using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais.Domain.CompanhiaOperante;

public class CompanhiasOperantesRepository : Repository<CompanhiasOperantes>
{
    private readonly ApiGhvcDbContext _dbContext;
    public CompanhiasOperantesRepository(ApiGhvcDbContext context) : base(context) { }

    public bool ExistsByNomeIgnoreCase(string nome)
    {
        return ExistsBy(companhiaOperante => companhiaOperante.Nome.ToLower().Trim() == nome.ToLower().Trim());
    }
}
