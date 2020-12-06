using Grpc.Core;
using Plebis.Membership.Models;
using Plebis.Membership.Storage;
using Plebis.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Plebis.Services.Membership;

namespace Plebis.Membership.Services
{
    public class MembershipService : MembershipBase
    {
        readonly MembershipStore membershipStore;
        public MembershipService(MembershipStore membershipStore)
        {
            this.membershipStore = membershipStore;
        }

        public override Task<AddMemberResponse> AddMember(AddMemberRequest request, ServerCallContext context)
        {
            var membership = new MembershipModel
            {
                Id = Guid.NewGuid().ToString(),
                OrganizationId = request.Organization,
                MemberId = request.Subject,
                MembershipType = request.Type
            };

            membershipStore.AddMembership(membership);

            return Task.FromResult(new AddMemberResponse()
            {
                MembershipId = membership.Id,
                Status = MembershipStatus.MembershipAdded
            });
        }

        public override Task<GetMembersResponse> AllMemberships(GetMembersRequest request, ServerCallContext context)
        {
            return base.AllMemberships(request, context);
        }

    }
}
