
using go_horse_voos_comerciais.Domain.Cliente;
using go_horse_voos_comerciais.Domain.Local;
using go_horse_voos_comerciais.Domain.Passagem;
using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using go_horse_voos_comerciais.Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;

namespace go_horse_voos_comerciais.Domain.Reserva;

public class ReservasService : IReservasService
{
    private readonly ApiGhvcDbContext _context;
    private readonly IPassagensService _passagensService;
    private readonly IRepository<Reservas> _reservasRepository;

    public ReservasService(ApiGhvcDbContext context, IPassagensService passagensService, IRepository<Reservas> reservasRepository)
    {
        _context = context;
        _passagensService = passagensService;
        _reservasRepository = reservasRepository;
    }

    public Task<DadosListagemReservasDTO> CadastraReserva(long? idVoo, string cpfCliente, FormaPagamento? formaPagamento, int? quantidadeAssentosDesejados)
    {
        Voos voo = _context.Voos.SingleOrDefault(voo => voo.Id.Equals(idVoo)) ?? throw new GhvcValidacaoException("Nenhum voo encontrado com o id fornecido!");

        Clientes cliente = _context.Clientes.SingleOrDefault(c => c.Cpf.Equals(cpfCliente)) ?? throw new GhvcValidacaoException("Nenhum cliente encontrado com esse CPF!");

        if (!Enum.IsDefined(typeof(FormaPagamento), formaPagamento)) throw new GhvcValidacaoException("Essa forma de pagamento não é aceita!");

        if (!(quantidadeAssentosDesejados.Value > 0)) throw new GhvcValidacaoException("Uma reserva precisa ter pelo menos um assento reservado!");

        int quantidadeAssentosOcupados = _context.Passagens
            .FromSql($@"SELECT p.id
                          FROM passagens p
                          JOIN reservas r
                            ON r.id = p.id_reserva
                         WHERE r.id_voo = {idVoo}
                           AND r.status_reserva = {StatusReserva.CONFIRMADA}")
            .Count();

        int quantidadeAssentosDisponiveis = voo.QuantidadeAssentosTotal - quantidadeAssentosOcupados;

        if (quantidadeAssentosDisponiveis < quantidadeAssentosDesejados)
        {
            string s = "Nenhum assento está disponível";
            if (quantidadeAssentosDisponiveis == 1) s = "Apenas 1 assento está disponível";
            if (quantidadeAssentosDisponiveis > 1) s = $"Apenas {quantidadeAssentosDisponiveis} assentos estão disponíveis";
            throw new GhvcValidacaoException($"{s} para este voo.");
        }

        Reservas reserva = new(idVoo.Value, cliente.Id, formaPagamento.Value);
        _context.Reservas.Add( reserva );
        _context.SaveChanges();

        List<Passagens> passagens = _passagensService.GerarPassagens(reserva.Id, quantidadeAssentosDesejados.Value);
        reserva.Passagens = passagens;
        _context.Passagens.AddRange(passagens);
        _context.SaveChanges();

        return Task.FromResult(new DadosListagemReservasDTO(reserva));
    }

    public void CancelaReserva(long? idReserva)
    {
        Reservas reservasParaCancelar = _context.Reservas.SingleOrDefault(r => r.Id.Equals(idReserva)) ?? throw new GhvcValidacaoException("Nenhuma reserva encontrada com o id informado!");
        if (reservasParaCancelar.StatusReserva.Equals(StatusReserva.CANCELADA)) throw new GhvcValidacaoException("A reserva já está cancelada!");
        reservasParaCancelar.StatusReserva = StatusReserva.CANCELADA;
        _context.SaveChanges();
    }

    public async Task<IEnumerable<DadosListagemReservasDTO>> ListaReservas()
    {
        var reservas = _reservasRepository.GetAll();

        var reservasDTOs = reservas
            .Select(reserva => new DadosListagemReservasDTO(reserva))
            .ToList();

        return await Task.FromResult(reservasDTOs);
    }
}
