using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PlebisID.Server.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlebisID.Server.Areas.Identity
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<PlebisUser, PlebisRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsPrincipalFactory`2"/> class.
        /// </summary>
        /// <param name="userManager">The <see cref="Microsoft.AspNetCore.Identity.UserManager`1"/> to retrieve user information from.</param>
        /// <param name="roleManager">The <see cref="Microsoft.AspNetCore.Identity.RoleManager`1"/> to retrieve a user's roles from.</param>
        /// <param name="options">The configured <see cref="Microsoft.AspNetCore.Identity.IdentityOptions"/>.</param>
        public ClaimsPrincipalFactory(UserManager<PlebisUser> userManager, RoleManager<PlebisRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {

        }
    }
}
