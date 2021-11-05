using System;
using System.Collections.Generic;

namespace Vendas.WebApi.Dtos
{
    public class VendaDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset Compra { get; set; }

        public VendedorDto Vendedor { get; set; }

        public IEnumerable<ProdutoDto> Produtos { get; set; }

        public class ProdutoDto
        {
            public Guid Id { get; set; }

            public string Nome { get; set; }

            public string Marca { get; set; }

            public string Categoria { get; set; }

            public decimal Valor { get; set; }
        }

        public class VendedorDto
        {
            public Guid Id { get; set; }

            public long Cpf { get; set; }

            public string Nome { get; set; }

            public string Email { get; set; }

            public string Telefone { get; set; }
        }
    }
}
