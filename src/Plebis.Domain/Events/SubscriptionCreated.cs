using Plebis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain.Events
{
    public class SubscriptionCreated : BaseDomainEvent<Subscription, Guid>
    {
        public SubscriptionCreated()
        {
            SubscriptionType = "Free";
        }

        public string Name { get; set; }
        public string SubscriptionType { get; set; }
    }
}
