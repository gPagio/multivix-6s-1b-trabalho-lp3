
using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais.Domain.Local
{
    public class LocaisRepository : Repository<Locais>, ILocaisRepository
    {
        private readonly ApiGhvcDbContext _dbContext;
        public LocaisRepository(ApiGhvcDbContext context) : base(context) {}

        public bool ExistsByNomeIgnoreCase(string nome)
        {
            return ExistsBy(local => local.Nome.ToLower().Trim() == nome.ToLower().Trim());
        }
    }
}
