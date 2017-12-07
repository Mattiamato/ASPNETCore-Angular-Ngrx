﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace FoodAPICore.STS
{
    public class IdentityConfig
    {
        // Identity resources (used by UserInfo endpoint).
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new List<string> { "role" })
            };
        }

        // Api resources.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("WebAPI" ) {
                    UserClaims = { "role" }
                }
            };
        }

        // Clients want to access resources.
        public static IEnumerable<Client> GetClients()
        {
            // Clients credentials.
            return new List<Client>
            {
                new Client
                {
                    ClientName = "AngularFoodClient",
                    ClientId = "AngularFoodClient",
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
	                IdentityTokenLifetime = 20,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200"

                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/unauthorized",
                        "http://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200"
                    },
                     AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "WebAPI"
                    },
                },
            };

        }
    }
}
