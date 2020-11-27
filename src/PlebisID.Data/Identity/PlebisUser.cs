using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PlebisID.Server.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PlebisUser class
    public class PlebisUser : IdentityUser
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}
