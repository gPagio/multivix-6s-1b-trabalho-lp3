namespace go_horse_voos_comerciais.Domain.Passagem;

public class BilheteDTO
{
    public long IdVoo { get; set; }
    public string? NomeCliente { get; set; }
    public int NumeroAssento { get; set; }
    public DateTime DataIda { get; set; }
    public DateTime DataVolta { get; set; }
    public string? Destino { get; set; }
    public string? Origem { get; set; }
}
