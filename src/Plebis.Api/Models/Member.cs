using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Api.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Type { get; set; }
    }
}
