using System;

namespace Vendas.Domain.Models
{
    public class AlteracaoVenda
    {
        public Guid Id { get; set; }

        public StatusVenda Status { get; set; }
    }
}
