using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlebisID.Server.Areas.Identity.Data;

[assembly: HostingStartup(typeof(PlebisID.Server.Areas.Identity.IdentityHostingStartup))]
namespace PlebisID.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PlebisIDContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("PlebisIDContextConnection"), sql => sql.MigrationsAssembly("PlebisID.Migrations.Sqlite")));

                services
                    .AddIdentity<PlebisUser, PlebisRole>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredUniqueChars = 0;
                        options.Password.RequiredLength = 8;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<PlebisIDContext>()
                    .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}