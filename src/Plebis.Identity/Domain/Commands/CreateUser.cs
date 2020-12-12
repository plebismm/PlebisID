using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity.Domain.Commands
{
    public class CreateUser : INotification
    {
        public CreateUser(Guid id, string givenName, string familyName, string password, string email)
        {
            Id = id;
            GivenName = givenName;
            FamilyName = familyName;
            Password = password;
            Email = email;
        }

        public Guid Id { get; }
        public string GivenName { get; }
        public string FamilyName { get; }
        public string Password { get; }
        public string Email { get; }

    }
}
