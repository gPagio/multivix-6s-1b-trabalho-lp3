public class Voo 
{
    public long Id { get; set; }
    public long IdOrigem { get; set; }
    public long IdDestino { get; set; }
    public DateTime DataIda { get; set; }
    public DateTime DataVolta { get; set; }
    public long IdCompanhiaOperante { get; set; }
    public double Preco { get; set; }
    public int QuantidadeAssentos { get; set; }
}