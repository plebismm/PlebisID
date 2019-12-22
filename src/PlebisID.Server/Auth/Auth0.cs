﻿using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlebisID.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Auth0
    {
        public static AuthenticationBuilder AddAuth0(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<Auth0Options> options)
        {
            var auth0Options = new Auth0Options()
            {

            };

            options(auth0Options);

            return builder.AddOpenIdConnect(authenticationScheme, displayName, options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                options.Authority = $"https://{auth0Options.Domain}";
                options.RequireHttpsMetadata = false;

                options.ClientId = auth0Options.ClientId;
                options.ClientSecret = auth0Options.ClientSecret;
                options.ResponseType = "code";

                options.Scope.Add("openid");
                options.Scope.Add("profile");

                options.CallbackPath = new PathString($"/signin-{authenticationScheme}");

                options.ClaimsIssuer = "Auth0";

                options.Events = new OpenIdConnectEvents
                {
                    OnTokenResponseReceived = (context) =>
                    {
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                        logger.LogInformation(context.TokenEndpointResponse.IdToken);
                        return Task.CompletedTask;
                    },
                    // handle the logout redirection
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{auth0Options.Domain}/v2/logout?client_id={auth0Options.ClientId}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }

    public class Auth0Options
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Domain { get; set; }
    }
}
