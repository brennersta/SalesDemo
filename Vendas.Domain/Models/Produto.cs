using System;

namespace Vendas.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        public Guid VendaId { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Categoria { get; set; }

        public decimal Valor { get; set; }
    }
}
