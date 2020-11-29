using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlebisID.Server
{
    public static class DbContextBuilderExtensions
    {
        public static DbContextOptionsBuilder UseConfiguredEngine(this DbContextOptionsBuilder builder, IConfiguration configuration, string connectionStringName)
        {
            var storageEngine = configuration["StorageEngine"];
            var connectionString = configuration.GetConnectionString(connectionStringName);
            return UseConfiguredEngine(builder, storageEngine, connectionString);
        }

        public static DbContextOptionsBuilder UseConfiguredEngine(this DbContextOptionsBuilder builder, string storageEngine, string connectionString)
        {
            if (storageEngine == "sqlserver")
            {
                builder.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly("PlebisID.Migrations.SqlServer"));
            }
            else
            {
                builder.UseSqlite(connectionString,
                    sql => sql.MigrationsAssembly("PlebisID.Migrations.Sqlite"));
            }
            return builder;
        }
    }
}
