namespace go_horse_voos_comerciais.Domain.Passagem;

public class PassagensService : IPassagensService
{

    private readonly ApiGhvcDbContext _context;

    public PassagensService(ApiGhvcDbContext context)
    {
        this._context = context;
    }
    public List<Passagens> GerarPassagens(long idReserva, int quantidadeAssentosDesejados)
    {
        List<Passagens> passagens = new List<Passagens>();
        for (int i = 0; i < quantidadeAssentosDesejados; i++)
        {
            passagens.Add(new Passagens(idReserva));
        }

        return passagens;
    }
}
