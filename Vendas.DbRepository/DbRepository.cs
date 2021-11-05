using System;
using System.Threading.Tasks;
using Vendas.DbRepository.Context;
using Vendas.Domain.Adapters;
using Vendas.Domain.Models;

namespace Vendas.DbRepository
{
    public class DbRepository : IDbRepository
    {
        private readonly DatabaseContext _context;

        public DbRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public async Task RegistrarVendaAsync(Pedido pedido)
        {

        }

        Task<Pedido> ObterVendaAsync(Guid idPedido);

        Task AtualizarVendaAsync(Guid idPedido, StatusPedido statusPedido);

        public bool Excluir(int id)
        {
            var obj = this.Obter(id);
            if (obj == null)
                return false;

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public EventoModel Incluir(EventoModel obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public EventoModel Alterar(EventoModel obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoModel> Listar()
        {
            return _context.Eventos.ToList();
        }

        public EventoModel Obter(int id)
        {
            return _context.Eventos.Where(a => a.EventoId == id).FirstOrDefault();
        }
    }
}
