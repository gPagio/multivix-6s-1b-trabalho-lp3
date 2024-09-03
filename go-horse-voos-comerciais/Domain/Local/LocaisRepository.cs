
namespace go_horse_voos_comerciais.Domain.Local
{
    public class LocaisRepository : ILocaisRepository
    {
        private readonly ApiGhvcDbContext _dbContext;
        public LocaisRepository(ApiGhvcDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Locais locais)
        {
            _dbContext.Locais.Add(locais);
            _dbContext.SaveChanges();
        }

        public List<Locais> GetAll()
        {
            return [.. _dbContext.Locais];
        }

        public bool ExistsByNomeIgnoreCase(string nome)
        {
            return _dbContext.Locais.Any(l => l.Nome.ToLower().Trim() == nome.ToLower().Trim());
        }
    }
}
