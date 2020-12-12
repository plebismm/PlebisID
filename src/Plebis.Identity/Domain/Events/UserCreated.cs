using Plebis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity.Domain.Events
{
    public class UserCreated : BaseDomainEvent<User, Guid>
    {
        private UserCreated() { }

        public UserCreated(User user) : base(user)
        {
            GivenName = user.GivenName;
            FamilyName = user.FamilyName;
            Email = user.Email;
        }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
    }

    public class UserPrimaryEmailConfirmed : BaseDomainEvent<User, Guid>
    {
        private UserPrimaryEmailConfirmed()
        {
            
        }

        public UserPrimaryEmailConfirmed(User user) : base(user)
        {

        }
    }

    public class UserPhonenumberUpdated : BaseDomainEvent<User, Guid>
    {
        public string Phonenumber { get; set; }
    }

    public class UserPhonenumberVerified : BaseDomainEvent<User, Guid>
    {
        public string Phonenumber { get; set; }
    }
}
