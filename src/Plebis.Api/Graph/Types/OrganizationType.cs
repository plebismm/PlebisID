using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Api.Graph.Types
{
    public class OrganizationType : ObjectGraphType<Organization>
    {
        public OrganizationType()
        {
            Name = "Organization";
            Field(h => h.Name).Description("Name of the organization");
            Field(h => h.Id).Description("Id of the organization");
        }
    }
}
