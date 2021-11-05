namespace Vendas.Domain.Models
{
    public enum StatusVenda
    {
        AguardandoPagamento = 1,
        PagamentoAprovado = 2,
        EnviadoTransportadora = 3,
        Entregue = 4,
        Cancelada = 5
    }
}
