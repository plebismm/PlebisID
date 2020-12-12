using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Plebis.Identity.Data
{
    public class PlebisDbContext : IdentityDbContext<PlebisUser>
    {
        public PlebisDbContext(DbContextOptions<PlebisDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityRole<string>>().HasData(new IdentityRole<string>
            {
                Id = "identityadmin",
                Name = "Administrator",
                NormalizedName = "ADMINSTRATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString("d")
            });
        }

        public DbSet<PlebisOrganization> Organizations { get; set; }
    }
}
