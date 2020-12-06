using Plebis.Core.Models;
using Plebis.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plebis.Domain
{
    public class Subscription : BaseAggregateRoot<Subscription, Guid>
    {
        protected override void Apply(IDomainEvent<Guid> @event)
        {
            switch (@event)
            {
                case SubscriptionCreated c:
                    Name = c.Name;
                    SubscriptionType = c.Name;
                    OwnedOrganizations = new List<Guid>();
                    break;
                case SubscriptionOrganizationAdded a:
                    OwnedOrganizations.Add(a.OrganizationId);
                    break;
                case SubscriptionDeleted:
                    Deleted = true;
                    break;
            }
        }

        public string Name { get; set; }
        public string SubscriptionType { get; set; }
        public IList<Guid> OwnedOrganizations { get; set; }
        public bool Deleted { get; set; }
    }
}
