using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendas.Domain.Adapters;
using Vendas.Domain.Models;
using Vendas.Domain.Services;
using Xunit;

namespace Vendas.Application.Tests
{
    public class VendasServiceTests
    {
        private readonly IVendasService vendasService;
        private readonly Mock<IDbRepository> dbRepositoryMock;

        public VendasServiceTests()
        {
            dbRepositoryMock = new Mock<IDbRepository>();
            this.vendasService = new VendasService(
                dbRepositoryMock.Object);
        }

        [Fact]
        public async Task RegistrarVendaAsync_Sucesso()
        {
            var vendaMock = new Venda()
            {
                Id = Guid.NewGuid(),
                Compra = DateTimeOffset.Now,
                Status = StatusVenda.AguardandoPagamento,
                Vendedor = new Vendedor()
                {
                    Id = Guid.NewGuid(),
                    Cpf = 123456789,
                    Email = "teste@teste.com",
                    Nome = "Brenner Silva",
                    Telefone = "33334444"
                },
                Produtos = new List<Produto>()
                {
                    new Produto()
                    {
                        Nome = "Água com gás",
                        Categoria = "Bebidas",
                        Marca = "Crystal",
                        Valor = 1.79m
                    }
                }
            };

            dbRepositoryMock
                .Setup(m => m.RegistrarVendaAsync(It.IsAny<Venda>()))
                .Callback<Venda>(
                    (venda) =>
                    {
                        Assert.Equal(vendaMock.Id,
                            venda.Id);
                        Assert.Equal(vendaMock.Status,
                            venda.Status);
                        Assert.Equal(vendaMock.Compra,
                            venda.Compra);
                    })
                .Returns(Task.CompletedTask);

            await vendasService.RegistrarVendaAsync(vendaMock);
        }

        [Fact]
        public async Task ObterVendaAsync_Sucesso()
        {
            var id = Guid.NewGuid();
            var vendaExpected = new Venda()
            {
                Id = id,
                Compra = DateTimeOffset.Now,
                Status = StatusVenda.AguardandoPagamento,
                Vendedor = new Vendedor()
                {
                    Id = Guid.NewGuid(),
                    Cpf = 123456789,
                    Email = "teste@teste.com",
                    Nome = "Brenner Silva",
                    Telefone = "33334444"
                },
                Produtos = new List<Produto>()
                {
                    new Produto()
                    {
                        Nome = "Água com gás",
                        Categoria = "Bebidas",
                        Marca = "Crystal",
                        Valor = 1.79m
                    }
                }
            };

            dbRepositoryMock
                 .Setup(m => m.ObterVendaAsync(It.IsAny<Guid>())).ReturnsAsync(vendaExpected);

            var actual = await vendasService.ObterVendaAsync(id);

            Assert.Equal(vendaExpected.Id, actual.Id);
        }

        [Fact]
        public async Task AtualizarVendaAsync_Sucesso()
        {
            var alteracaoVendaExpected = new AlteracaoVenda()
            {
                Id = Guid.NewGuid(),
                Status = StatusVenda.PagamentoAprovado
            };

            var vendaMock = new Venda()
            {
                Id = Guid.NewGuid(),
                Compra = DateTimeOffset.Now,
                Status = StatusVenda.AguardandoPagamento,
                Vendedor = new Vendedor()
                {
                    Id = Guid.NewGuid(),
                    Cpf = 123456789,
                    Email = "teste@teste.com",
                    Nome = "Brenner Silva",
                    Telefone = "33334444"
                },
                Produtos = new List<Produto>()
                {
                    new Produto()
                    {
                        Nome = "Água com gás",
                        Categoria = "Bebidas",
                        Marca = "Crystal",
                        Valor = 1.79m
                    }
                }
            };

            dbRepositoryMock
                 .Setup(m => m.ObterVendaAsync(It.IsAny<Guid>())).ReturnsAsync(vendaMock);

            dbRepositoryMock
                 .Setup(m => m.AtualizarVendaAsync(It.IsAny<AlteracaoVenda>()))
                 .Callback<AlteracaoVenda>(
                     (alteracaoVenda) =>
                     {
                         Assert.Equal(alteracaoVendaExpected.Id,
                             alteracaoVenda.Id);
                         Assert.Equal(alteracaoVendaExpected.Status,
                             alteracaoVenda.Status);
                     })
                 .Returns(Task.CompletedTask);

            await vendasService.AtualizarVendaAsync(alteracaoVendaExpected);
        }
    }
}
