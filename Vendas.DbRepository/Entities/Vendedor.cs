using System;
using System.ComponentModel.DataAnnotations;

namespace Vendas.DbRepository.Entities
{
    public class Vendedor
    {
        [Key]
        public Guid Id { get; set; }

        public long Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
