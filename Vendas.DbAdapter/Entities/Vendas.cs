using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vendas.DbRepository.Entities
{
    public class Vendas
    {
        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset Compra { get; set; }

        public Vendedores Vendedor { get; set; }

        public IEnumerable<Produtos> Produtos { get; set; }

        public int Status { get; set; }
    }
}
