using Plebis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain.Events
{
    public class OrganizationCreated : BaseDomainEvent<Organization, Guid>
    {
        public OrganizationCreated()
        {

        }

        public OrganizationCreated(Organization organization, Subscription subscription) : base(organization)
        {
            SubscriptionId = subscription.Id;
            Name = organization.Name;
        }

        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }

        public string OwnerId { get; set; }
    }
    
    public class OrganizationMemberAdded : BaseDomainEvent<Organization, Guid>
    {
        public Guid UserId { get; set; }
        public string MembershipType { get; set; }
        public DateTimeOffset? Expires { get; set; }
    }

    public class OrganizationMemberRemoved : BaseDomainEvent<Organization, Guid>
    {
        public Guid UserId { get; set; }
    }

    public class OrganizationMemberExpired : BaseDomainEvent<Organization, Guid>
    {
        public Guid MemberId { get; set; }
    }

    public class OrganizationMemberActivated : BaseDomainEvent<Organization, Guid>
    {
        public Guid MemberId { get; set; }
        public DateTimeOffset? Expires { get; set; }
    }
}
