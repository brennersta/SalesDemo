using System;
using System.Collections.Generic;

namespace Vendas.Domain.Models
{
    public class Venda
    {
        public Guid Id { get; set; }

        public DateTimeOffset Compra { get; set; }

        public Vendedor Vendedor { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

        public StatusVenda Status { get; set; }
    }
}
