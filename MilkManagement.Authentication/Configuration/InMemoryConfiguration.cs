using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace MilkManagement.Authentication.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("milkmanagement", "Milk Management")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "native.code",
                    ClientName = "Native Client (Code with PKCE)",
                    RequireClientSecret = false,

                    RedirectUris = new List<string> { "io.identityserver.demo:/oauthredirect","https://www.getpostman.com/oauth2/callback" },
                    PostLogoutRedirectUris = new List<string> { "https://www.getpostman.com" },
                    AllowedCorsOrigins = new List<string> { "https://www.getpostman.com" },
                    RequireConsent =  false,

                    AllowedGrantTypes = GrantTypes.Code,
                    //RequirePkce = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "milkmanagement"
                    },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                }

            };
            //ClientId = "native.code",
            //ClientName = "Native Client (Code with PKCE)",
            //RequireClientSecret = false,

            //RedirectUris = { "io.identityserver.demo:/oauthredirect" },

            //AllowedGrantTypes = GrantTypes.Code,
            //RequirePkce = true,
            //AllowedScopes = { "openid", "profile" },
            //AllowOfflineAccess = true
        }


        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "uzair.qq@outlook.com",
                    Password = "password123",
                    Claims = new[] {new Claim("email", "uzair.qq@outlook.com")}
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username = "uzair.qq@gmail.com",
                    Password = "password12345"
                }
            };
        }
    }
}
