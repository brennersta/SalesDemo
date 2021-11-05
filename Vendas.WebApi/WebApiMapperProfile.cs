using AutoMapper;
using Vendas.Domain.Models;
using Vendas.WebApi.Dtos;

namespace Vendas.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<VendaPost, Venda>();
            CreateMap<Venda, VendaPost>();
            CreateMap<VendaPatch, AlteracaoVenda>();
            CreateMap<StatusVendaDto, StatusVenda>();

            CreateMap<VendaDto, Venda>();
            CreateMap<VendaDto.ProdutoDto, Produto>();
            CreateMap<VendaDto.VendedorDto, Vendedor>();

            CreateMap<Venda, VendaDto>();
            CreateMap<Produto, VendaDto.ProdutoDto>();
            CreateMap<Vendedor, VendaDto.VendedorDto>();

            CreateMap<Venda, VendaGetResult>();
        }
    }
}