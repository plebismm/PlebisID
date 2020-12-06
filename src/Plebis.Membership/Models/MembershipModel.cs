using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Membership.Models
{
    public class MembershipModel
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string OrganizationId { get; set; }
        public string MembershipType { get; set; }
    }
}
