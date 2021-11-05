using System;

namespace Vendas.Domain.Models
{
    public class Vendedor
    {
        public Guid Id { get; set; }

        public Guid VendaId { get; set; }

        public long Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
