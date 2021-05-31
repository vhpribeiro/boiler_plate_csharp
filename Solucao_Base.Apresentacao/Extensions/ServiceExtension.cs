using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Solucao_Base.Dominio;
using Solucao_Base.Infra._Helpers;
using Solucao_Base.Infra.Repositorios;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Solucao_Base.Apresentacao.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            services.AddSwaggerGen(options =>
            {
                options.ExampleFilters();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Boiler plate para futuros projetos no .NET 5.",
                    License = new OpenApiLicense
                    {
                        Name = "© Todos os direitos reservados."
                    },
                    Title = "Solução Base API",
                    Version = "v1"
                });
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntidadeBaseRepository<>), typeof(EntidadeBaseRepository<>));
        }

        public static void AddPostgreSql(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringFactory, ConnectionStringFactory>();

            var connectionString = services.BuildServiceProvider()
                .GetRequiredService<IConnectionStringFactory>()
                .GetConnectionString();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(connectionString, builder =>
                    builder.MigrationsAssembly("Solucao_Base.Infra")));
        }
    }
}
