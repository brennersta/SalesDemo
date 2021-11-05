using Microsoft.EntityFrameworkCore;
using System;
using Vendas.DbRepository;
using Vendas.DbRepository.Context;
using Vendas.Domain.Adapters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddDbAdapter(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IDbRepository, DbRepository>()
                .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("test"));

            return services;
        }
    }
}
