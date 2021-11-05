using System;
using System.Threading.Tasks;
using Vendas.Domain.Models;

namespace Vendas.Domain.Adapters
{
    public interface IDbRepository
    {
        /// <summary>
        ///     Insere nova venda.
        /// </summary>
        /// <param name="venda">
        ///     Dados da venda a ser registrada
        /// </param>
        Task RegistrarVendaAsync(Venda venda);

        /// <summary>
        ///     Retorna os dados da venda de acordo com o ID informado.
        /// </summary>
        /// <param name="idVenda">
        ///     Id da venda
        /// </param>
        /// <returns>
        ///     Dados da venda
        /// </returns>
        Task<Venda> ObterVendaAsync(Guid idVenda);

        /// <summary>
        ///     Atualiza o status da venda.
        /// </summary>
        /// <param name="alteracaoVenda">
        ///     Informa��es da venda e status a ser alterado
        /// </param>
        Task AtualizarVendaAsync(AlteracaoVenda alteracaoVenda);
    }
}
