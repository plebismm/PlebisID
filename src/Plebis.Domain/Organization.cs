using Plebis.Core.Models;
using Plebis.Domain.Events;
using Plebis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain
{
    public class Organization : BaseAggregateRoot<Organization, Guid>
    {
        public Organization()
        {
            Members = new Dictionary<Guid, Membership>();
        }

        protected override void Apply(IDomainEvent<Guid> @event)
        {
            switch (@event)
            {
                case OrganizationCreated created:
                    this.Id = created.AggregateId;
                    this.Name = created.Name;
                    this.SubscriptionId = created.SubscriptionId;
                    this.OwnerId = created.OwnerId;
                    break;
                case OrganizationMemberAdded added:
                    this
                        .Members
                        .Add(added.UserId, 
                            new Membership { 
                                Started = added.Timestamp, 
                                Active = true, 
                                Type = added.MembershipType, 
                                Expires = added.Expires 
                            });
                    break;
                case OrganizationMemberExpired expired:
                    this.Members[expired.MemberId].Active = false;
                    break;
                case OrganizationMemberActivated activated:
                    this.Members[activated.MemberId].Active = true;
                    this.Members[activated.MemberId].Expires = activated.Expires;
                    break;
                case OrganizationMemberRemoved removed:
                    this.Members.Remove(removed.UserId);
                    break;
            }
        }

        public Guid SubscriptionId { get; set; }

        public string Name { get; set; }

        public IDictionary<Guid, Membership> Members { get; set; }

        public string OwnerId { get; set; }
    }
}
