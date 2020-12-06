using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain.Events
{
    public class SubscriptionOrganizationAdded : BaseDomainEvent<Subscription, Guid>
    {
        public Guid OrganizationId { get; set; }
    }
}
