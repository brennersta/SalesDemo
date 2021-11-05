using System;
using Vendas.DbRepository;
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


            services.AddScoped<IDbRepository, DbRepository>();
                //.AddScoped<IEventoRepository, EventoRepository>()
                //.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("test"))

            return services;
        }
    }
}
