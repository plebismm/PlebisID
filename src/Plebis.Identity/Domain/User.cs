using Plebis.Core.Models;
using Plebis.Identity.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity.Domain
{
    public class User : BaseAggregateRoot<User, Guid>
    {
        public User(Guid id, string givenName, string familyName, string email) : base(id)
        {
            if (string.IsNullOrWhiteSpace(givenName))
                throw new ArgumentOutOfRangeException(nameof(givenName));
            if (string.IsNullOrWhiteSpace(familyName))
                throw new ArgumentOutOfRangeException(nameof(familyName));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentOutOfRangeException(nameof(email));

            GivenName = givenName;
            FamilyName = familyName;
            Email = email;

            this.AddEvent(new UserCreated(this));
        }

        public void ConfirmEmail()
        {
            this.AddEvent(new UserPrimaryEmailConfirmed(this));
        }

        protected override void Apply(IDomainEvent<Guid> @event)
        {
            switch (@event)
            {
                case UserCreated u:
                    this.Id = u.AggregateId;
                    this.GivenName = u.GivenName;
                    this.FamilyName = u.FamilyName;
                    this.Email = u.Email;
                    break;
                case UserPrimaryEmailConfirmed c:
                    this.EmailConfirmed = true;
                    break;
            }
        }

        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }
        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
    }
}
