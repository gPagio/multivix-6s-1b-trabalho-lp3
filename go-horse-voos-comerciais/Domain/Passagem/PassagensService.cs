using go_horse_voos_comerciais.Domain.Reserva;
using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using Microsoft.EntityFrameworkCore;

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

    public void RealizarCheckIn(long idPassagem, int numeroAssentoDesejado)
    {
        Passagens passagem = _context.Passagens.FirstOrDefault(p => p.Id.Equals(idPassagem)) ?? throw new GhvcValidacaoException("Nenhuma passagem encontrada com o id da passagem informado!");
        Reservas reserva = _context.Reservas.FirstOrDefault(r => r.Id.Equals(passagem.IdReserva)) ?? throw new GhvcValidacaoException("Nenhuma reserva encontrada com o id da passagem informado!");
        Voos voo = _context.Voos.FirstOrDefault(v => v.Id.Equals(reserva.IdVoo)) ?? throw new GhvcValidacaoException("Nenhum voo encontrado com o id da passagem informado!");

        if ((voo.DataIda - DateTime.Now).TotalHours > 24) throw new GhvcValidacaoException($"O checkin poderá ser realizado a patir de {voo.DataIda.AddHours(-24)}!");
        if ((voo.DataIda - DateTime.Now).TotalHours < 1) throw new GhvcValidacaoException($"O checkin poderia ser realizado a até {voo.DataIda.AddHours(-1)}!");

        if (!(numeroAssentoDesejado > 0) || numeroAssentoDesejado > voo.QuantidadeAssentosTotal)
            throw new GhvcValidacaoException($"O assento deve estar entre 1 e {voo.QuantidadeAssentosTotal} para este voo!");

        bool assentoDesajadoEstaOcupado = _context.Passagens
            .FromSql($@"SELECT p.id
                          FROM voos v
                          JOIN reservas r
                            ON r.id_voo = v.id
                          JOIN passagens p
                            ON p.id_reserva = r.id
                         WHERE v.id = {voo.Id}
                           AND p.numero_assento = {numeroAssentoDesejado}")
            .Any();

        if (assentoDesajadoEstaOcupado) throw new GhvcValidacaoException($"O assento {numeroAssentoDesejado} está ocupado para esta voo!");



        passagem.NumeroAssento = numeroAssentoDesejado;
        passagem.SituacaoCheckIn = SituacaoCheckIn.REALIZADO;
        _context.SaveChanges();
    }
}