using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


[assembly: HostingStartup(typeof(PlebisID.Server.Areas.IdentityServer.IdentityServerHostingStartup))]
namespace PlebisID.Server.Areas.IdentityServer
{
    public class IdentityServerHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                var migrationsAssembly = typeof(IdentityServerHostingStartup).GetTypeInfo().Assembly.GetName().Name;

                var identityServerBuilder = services.AddIdentityServer()
                    .AddConfigurationStore(options =>
                    {
                        options.ConfigureDbContext = b => b.UseSqlite(context.Configuration.GetConnectionString("ConfigurationDbConnection"),
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                    })
                    .AddOperationalStore(options =>
                    {
                        options.ConfigureDbContext = b => b.UseSqlite(context.Configuration.GetConnectionString("PersistedGrantDbConnection"),
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                    });

                // not recommended for production - you need to store your key material somewhere secure
                identityServerBuilder.AddDeveloperSigningCredential();
            });
        }
    }
}
