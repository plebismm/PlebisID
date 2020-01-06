// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace PlebisID.Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            { 
                new ApiResource("membership.read", "My API")
            };
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client
                {
                    ClientId = "plebisid-testapp",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "membership.read" }
                },
                new Client
                {
                    ClientId = "plebis-mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,

                    //AllowedCorsOrigins = { "https://dev-9nlk4lao.eu.auth0.com" },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address
                    }
                },
                new Client
                {
                    ClientName = "VueJS Sample Client",
                    ClientId = "vuejs_code_client",
                    AccessTokenType = AccessTokenType.Reference,
                    // RequireConsent = false,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 300,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:5005",
                        "https://localhost:5005/callback.html",
                        "https://localhost:5005/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:5005/",
                        "https://localhost:5005"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:5005"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "role",
                        "profile",
                        "email"
                    }
                }
            };
        
    }
}