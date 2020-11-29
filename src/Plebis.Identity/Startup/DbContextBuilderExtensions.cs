using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity
{
    public static class DbContextBuilderExtensions
    {
        public static DbContextOptionsBuilder UseConfiguredEngine(this DbContextOptionsBuilder builder, IConfiguration configuration, string connectionStringName)
        {
            var storageEngine = configuration["StorageEngine"] ?? "sqlite";
            var connectionString = configuration.GetConnectionString(connectionStringName);
            return UseConfiguredEngine(builder, storageEngine, connectionString);
        }

        public static DbContextOptionsBuilder UseConfiguredEngine(this DbContextOptionsBuilder builder, string storageEngine, string connectionString)
        {
            if (storageEngine.ToLower() == "sqlserver")
            {
                builder.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly("Plebis.Identity.Data.Migrations.SqlServer"));
            }
            else
            {
                builder.UseSqlite(connectionString,
                    sql => sql.MigrationsAssembly("Plebis.Identity.Data.Migrations.Sqlite"));
            }
            return builder;
        }
    }
}
