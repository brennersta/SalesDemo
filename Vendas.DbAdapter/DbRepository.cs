using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vendas.DbRepository.Context;
using Vendas.DbRepository.Entities;
using Vendas.Domain.Adapters;
using Vendas.Domain.Models;

namespace Vendas.DbRepository
{
    public class DbRepository : IDbRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper mapper;

        public DbRepository(DatabaseContext ctx, IMapper mapper)
        {
            _context = ctx;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task RegistrarVendaAsync(Venda venda)
        {
            var vendas = mapper.Map<Venda, Entities.Vendas>(venda);

            _context.Add(vendas);
            await Task.FromResult(_context.SaveChanges());
        }

        public async Task<Venda> ObterVendaAsync(Guid idVenda)
        {
            var vendas = await Task.FromResult(
                _context.Vendas.Where(a => a.Id == idVenda)
                .Include(u => u.Produtos).Include(u => u.Vendedor).FirstOrDefault());

            var venda = mapper.Map<Entities.Vendas, Venda>(vendas);

            return venda;
        }

        public async Task AtualizarVendaAsync(AlteracaoVenda alteracaoVenda)
        {
            var vendas = await Task.FromResult(
                   _context.Vendas.Where(a => a.Id == alteracaoVenda.Id).FirstOrDefault());
            vendas.Status = (int)alteracaoVenda.Status;
            await Task.FromResult(_context.SaveChanges());
        }
    }
}
