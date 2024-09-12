
using go_horse_voos_comerciais.Domain.Cliente;
using go_horse_voos_comerciais.Domain.Passagem;
using go_horse_voos_comerciais.Domain.Voo;
using go_horse_voos_comerciais.Infraestrutura.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace go_horse_voos_comerciais.Domain.Reserva;

public class ReservasService : IReservasService
{
    private readonly ApiGhvcDbContext _context;
    private readonly IPassagensService _passagensService;

    public ReservasService(ApiGhvcDbContext context, IPassagensService passagensService)
    {
        this._context = context;
        this._passagensService = passagensService;
    }

    public Task<DadosListagemReservasDTO> CadastraReserva(long? idVoo, string cpfCliente, FormaPagamento? formaPagamento, int? quantidadeAssentosDesejados)
    {
        Voos voo = _context.Voos.SingleOrDefault(voo => voo.Id.Equals(idVoo)) ?? throw new GhvcValidacaoException("Nenhum voo encontrado com o id fornecido!");

        Clientes cliente = _context.Clientes.SingleOrDefault(c => c.Cpf.Equals(cpfCliente)) ?? throw new GhvcValidacaoException("Nenhum cliente encontrado com esse CPF!");

        if (!Enum.IsDefined(typeof(FormaPagamento), formaPagamento)) throw new GhvcValidacaoException("Essa forma de pagamento não é aceita!");

        int quantidadeAssentosOcupados = _context.Passagens
            .FromSql($@"SELECT p.id
                          FROM passagens p
                          JOIN reservas r
                            ON r.id = p.id_reserva
                         WHERE r.id_voo = {idVoo}")
            .Count();

        int quantidadeAssentosDisponiveis = voo.QuantidadeAssentos - quantidadeAssentosOcupados;

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

    public Task<DadosListagemReservasDTO> CancelaReserva(long? idReserva)
    {
        throw new NotImplementedException();
    }
}
