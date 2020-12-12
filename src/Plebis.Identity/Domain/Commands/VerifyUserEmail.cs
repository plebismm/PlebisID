using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity.Domain.Commands
{
    public class VerifyUserEmail : INotification
    {
        public Guid UserId { get; }
        public string Code { get; }
    }
}
