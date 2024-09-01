namespace go_horse_voos_comerciais.Domain.Local
{
    public interface ILocaisRepository
    {
        void Add(Locais locais);

        List<Locais> GetAll();
    }
}
