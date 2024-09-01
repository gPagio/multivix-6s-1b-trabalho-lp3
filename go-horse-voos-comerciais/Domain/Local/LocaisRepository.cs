﻿
namespace go_horse_voos_comerciais.Domain.Local
{
    public class LocaisRepository : ILocaisRepository
    {
        public readonly ApiGhvcDbContext _contexto = new ApiGhvcDbContext();
        public void Add(Locais locais)
        {
            _contexto.Locais.Add(locais);
            _contexto.SaveChanges();
        }

        public List<Locais> GetAll()
        {
            return _contexto.Locais.ToList();
        }
    }
}
