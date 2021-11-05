using System;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Domain.Adapters;
using Vendas.Domain.Models;
using Vendas.Domain.Services;

namespace Vendas.Application
{
    public class VendasService : IVendasService
    {
        private readonly IDbRepository dbRepository;

        public VendasService(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository ??
                throw new ArgumentNullException(nameof(dbRepository));
        }

        public async Task RegistrarVendaAsync(Venda venda)
        {
            if (venda is null)
            {
                throw new ArgumentNullException(nameof(venda));
            }

            if (!venda.Produtos.Any())
                throw new InvalidOperationException("as vendas devem possuir no mínimo um produto.");

            venda.Vendedor.VendaId = venda.Id;
            venda.Produtos.ToList().ForEach(u => u.VendaId = venda.Id);
            venda.Status = StatusVenda.AguardandoPagamento;

            await dbRepository.RegistrarVendaAsync(venda);
        }
        public async Task<Venda> ObterVendaAsync(Guid idVenda)
        {
            if (idVenda == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idVenda));
            }

            var venda = await dbRepository.ObterVendaAsync(idVenda);

            return venda;
        }

        public async Task AtualizarVendaAsync(AlteracaoVenda alteracaoVenda)
        {
            if (alteracaoVenda is null)
            {
                throw new ArgumentNullException(nameof(alteracaoVenda));
            }

            var venda = await ObterVendaAsync(alteracaoVenda.Id);

            switch (venda.Status)
            {
                case StatusVenda.AguardandoPagamento:
                    if(alteracaoVenda.Status != StatusVenda.PagamentoAprovado && alteracaoVenda.Status != StatusVenda.Cancelada)
                        throw new InvalidOperationException($"O status {StatusVenda.AguardandoPagamento} só pode ser alterado para " +
                            $"{StatusVenda.PagamentoAprovado} ou {StatusVenda.Cancelada}.");
                    break;
                case StatusVenda.PagamentoAprovado:
                    if (alteracaoVenda.Status != StatusVenda.EnviadoTransportadora && alteracaoVenda.Status != StatusVenda.Cancelada)
                        throw new InvalidOperationException($"O status {StatusVenda.PagamentoAprovado} só pode ser alterado para " +
                            $"{StatusVenda.EnviadoTransportadora} ou {StatusVenda.Cancelada}.");
                    break;
                case StatusVenda.EnviadoTransportadora:
                    if (alteracaoVenda.Status != StatusVenda.Entregue)
                        throw new InvalidOperationException($"O status {StatusVenda.EnviadoTransportadora} " +
                            $"só pode ser alterado para {StatusVenda.Entregue}.");
                    break;
                default:
                        throw new InvalidOperationException($"Venda no status {venda.Status} e não pode ser alterado.");
            }

            await dbRepository.AtualizarVendaAsync(alteracaoVenda);
        }
    }
}
