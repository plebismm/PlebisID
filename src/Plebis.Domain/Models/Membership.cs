using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Domain.Models
{
    public class Membership
    {
        public string Type { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? Started { get; set; }
    }
}
