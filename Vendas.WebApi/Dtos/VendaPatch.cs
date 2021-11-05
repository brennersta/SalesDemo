using System;

namespace Vendas.WebApi.Dtos
{
    public class VendaPatch
    {
        public Guid Id { get; set; }

        public StatusVendaDto Status { get; set; }
    }
}
