using System;
using System.ComponentModel.DataAnnotations;

namespace Vendas.DbRepository.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Categoria { get; set; }

        public decimal Valor { get; set; }
    }
}
