using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Plebis.Api.Graph.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plebis.Api.Graph
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
            
        }
    }

    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery()
        {
            Name = "Query";

            Func<IResolveFieldContext, string, object> func = (context, id) => new Organization { Id = id, Name = "Some random organization" };

            FieldDelegate<OrganizationType>(
                "organization",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the organization" }
                ),
                resolve: func
            );
        }
    }

    public class OrganizationType : ObjectGraphType<Organization>
    {
        public OrganizationType(Services.Membership.MembershipClient membershipClient)
        {
            Name = "Organization";

            Field(h => h.Id).Description("Id of the organizaton");
            Field(h => h.Name).Description("Name of the organization");

            Func<IResolveFieldContext, string, IEnumerable<Models.Member> > func = 
                (context, id) => 
                membershipClient
                .AllMemberships(new Services.GetMembersRequest { Organization = id })
                .Members.Select((m) => new Models.Member { Id = m.Member });

            Field<ListGraphType<MemberType>>(
                "members",
                resolve: context =>
                    membershipClient
                        .AllMemberships(new Services.GetMembersRequest { Organization = context.Source.Id })
                        .Members.Select((m) => new Models.Member { Id = m.Member })
            );
            
        }
    }
}
