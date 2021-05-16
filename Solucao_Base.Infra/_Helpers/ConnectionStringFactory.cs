using Npgsql;
using System;

namespace Solucao_Base.Infra._Helpers
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private string Host => Environment.GetEnvironmentVariable("POSTGRESQL_HOST") ?? "127.0.0.1";
        private int Port => int.Parse(Environment.GetEnvironmentVariable("POSTGRESQL_PORT") ?? "5432");
        private string Database => Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE") ?? "default_database";
        private string Username => Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME") ?? "postgres";
        private string Password => Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD") ?? "admin";
        private string SSlMode => Environment.GetEnvironmentVariable("POSTGRESQL_SSL_MODE") ?? "Disable";
        private int MinimumPoolSize => int.Parse(Environment.GetEnvironmentVariable("POSTGRESQL_MINIMUM_POOL_SIZE") ?? "10");
        private int MaximumPoolSize => int.Parse(Environment.GetEnvironmentVariable("POSTGRESQL_MAXIMUM_POOL_SIZE") ?? "20");
        private int CommandTimeout => int.Parse(Environment.GetEnvironmentVariable("POSTGRESQL_COMMAND_TIMEOUT") ?? "60");

        public string GetConnectionString()
        {
            return new NpgsqlConnectionStringBuilder
            {
                Host = Host,
                Port = Port,
                Database = Database,
                Username = Username,
                Password = Password,
                SslMode = Enum.Parse<SslMode>(SSlMode),
                MinPoolSize = MinimumPoolSize,
                MaxPoolSize = MaximumPoolSize,
                CommandTimeout = CommandTimeout,
                Pooling = false
            }.ToString();
        }
    }
}
