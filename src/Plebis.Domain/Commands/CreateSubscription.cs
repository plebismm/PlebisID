using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain.Commands
{
    public class CreateSubscription
    {
        /// <summary>
        /// User ID that created the subscription
        /// </summary>
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
