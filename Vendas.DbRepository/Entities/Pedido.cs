using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vendas.DbRepository.Entities
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset Compra { get; set; }

        public Vendedor Vendedor { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

        public int Status { get; set; }
    }
}
