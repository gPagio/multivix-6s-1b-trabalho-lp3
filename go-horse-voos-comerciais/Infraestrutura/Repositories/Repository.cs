namespace go_horse_voos_comerciais.Infraestrutura.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApiGhvcDbContext _context;

    public Repository(ApiGhvcDbContext context)
    {
        _context = context; 
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public List<T> GetAll() 
    {
        return _context.Set<T>().ToList();
    }

    public bool ExistsBy(Func<T, bool> predicate)
    {
        return _context.Set<T>().Any(predicate);
    }
}
