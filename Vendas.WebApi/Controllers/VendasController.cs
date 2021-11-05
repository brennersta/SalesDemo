using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vendas.Domain.Models;
using Vendas.Domain.Services;
using Vendas.WebApi.Dtos;

namespace Vendas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendasService vendasService;
        private readonly IMapper mapper;

        public VendasController(IVendasService vendasService,
            IMapper mapper)
        {
            this.vendasService = vendasService ??
                throw new ArgumentNullException(nameof(vendasService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        ///     Registra uma venda
        /// </summary>
        /// <param name="vendaPost">
        ///     Informações sobre a venda.
        /// </param>
        [HttpPost("{Id}")]
        public async Task<OkResult> RegistrarVendaAsync(
            [FromRoute] Guid Id, 
            [FromBody] VendaPost vendaPost)
        {
            var venda = mapper.Map<VendaPost, Venda>(vendaPost);
            venda.Id = Id;

            await vendasService.RegistrarVendaAsync(venda);

            return Ok();
        }

        /// <summary>
        ///     Busca a venda pelo identificador
        /// </summary>
        /// <param name="Id">
        ///     Identificador da venda.
        /// </param>
        /// <response code="200">
        ///     Retorna os dados da venda
        /// </response>
        [HttpGet("{Id}")]
        public async Task<VendaGetResult> ObterVendaAsync(
            [FromRoute] Guid Id)
        {
            var venda =
               await vendasService.ObterVendaAsync(Id);

            var vendaGetResult = mapper.Map<Venda, VendaGetResult>(venda);

            return vendaGetResult;
        }

        /// <summary>
        ///     Altera o status da venda
        /// </summary>
        /// <param name="vendaPatch">
        ///     Novo status da venda.
        /// </param>
        /// <response code="500">
        ///     Status informado inválido
        /// </response>
        [HttpPatch("{Id}")]
        public async Task<OkResult> AtualizarVendaAsync(
            [FromRoute] Guid Id,
            [FromBody] VendaPatch vendaPatch)
        {
            var alteracaoVenda = mapper.Map<VendaPatch, AlteracaoVenda>(vendaPatch);

            alteracaoVenda.Id = Id;

               await vendasService.AtualizarVendaAsync(alteracaoVenda);

            return Ok();
        }
    }
}
