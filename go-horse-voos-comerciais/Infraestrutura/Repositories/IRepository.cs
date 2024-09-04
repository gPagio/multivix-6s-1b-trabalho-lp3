namespace go_horse_voos_comerciais.Infraestrutura.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    List<T> GetAll();
    bool ExistsBy(Func<T, bool> predicate);
}
