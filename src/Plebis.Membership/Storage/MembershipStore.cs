using Plebis.Membership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Membership.Storage
{
    public class MembershipStore
    {
        private IList<MembershipModel> memberships;

        public MembershipStore()
        {
            memberships = new List<MembershipModel>();
        }

        public Task AddMembership(MembershipModel membership)
        {
            return Task.CompletedTask;
        }
    }
}
