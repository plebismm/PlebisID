using GraphQL.Types;
using Plebis.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Api.Graph.Types
{
    public class MemberType : ObjectGraphType<Member>
    {
        public MemberType()
        {
            Name = "Member";
            Field(h => h.FamilyName).Description("Family name of the member");
            Field(h => h.GivenName).Description("Given name of the member");
            Field(h => h.Type).Description("Membership type");
        }
    }
}
