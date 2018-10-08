using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using StackExchange.Redis;
using System.Security.Cryptography;
using IdentityServer4;

namespace MilkManagement.OAuth.Configuration
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
                    ClientId = "milkmanagement", //client id and client secret will always retreive with the token
                    ClientSecrets = new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "milkmanagement"
                    }
                }
            };
        }
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(), 
                new IdentityResources.Profile()
            };
        }


        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "uzair.qq@outlook.com",
                    Password = "password123"
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username = "laraib.aiit@hotmail.com",
                    Password = "password12345"
                }	                
            };
        }

    }
}
