using AutoMapper;
using Vendas.DbRepository.Entities;
using Vendas.Domain.Models;

namespace Vendas.DbRepository
{
    public class DbRepositoryMapperProfile : Profile
    {
        public DbRepositoryMapperProfile()
        {
            CreateMap<Venda, Entities.Vendas>();
            CreateMap<Produto, Produtos>()
                .ForPath(d => d.VendasId, o => o.MapFrom(s => s.VendaId));
            CreateMap<Vendedor, Vendedores>()
                .ForPath(d => d.VendasId, o => o.MapFrom(s => s.VendaId));
            CreateMap<Entities.Vendas, Venda>();
            CreateMap<Produtos, Produto>()
                .ForPath(d => d.VendaId, o => o.MapFrom(s => s.VendasId));
            CreateMap<Vendedores, Vendedor>()
                .ForPath(d => d.VendaId, o => o.MapFrom(s => s.VendasId));
        }
    }
} 