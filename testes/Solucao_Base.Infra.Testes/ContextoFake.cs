using Microsoft.EntityFrameworkCore;
using Solucao_Base.Infra._Helpers;

namespace Solucao_Base.Infra.Testes
{
    public static class ContextoFake
    {
        private static DatabaseContext ObterContexto()
        {
            DbContextOptions<DatabaseContext> options;
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase("prova_sbf_database");
            options = builder.Options;
            DatabaseContext databaseContext = new DatabaseContext(options);
            databaseContext.Database.EnsureDeleted();
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}
