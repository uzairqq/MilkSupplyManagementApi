﻿using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MilkManagement.Client
{
    public class Program
    {
        private static async Task Main()
        {
            
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:4000");
            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "ro.client",
                ClientSecret = "secret",

                UserName = "uzairqq",
                Password = "Super@123",
                Scope = "milkManagement"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            
            
            
            // discover endpoints from metadata
            //Identity Server
//            var client = new HttpClient();
//
//            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:4000");
//            if (disco.IsError)
//            {
//                Console.WriteLine(disco.Error);
//                return;
//            }
//
//            // request token
//            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
//            {
//                Address = disco.TokenEndpoint,
//                ClientId = "client",
//                ClientSecret = "secret",
//
//                Scope = "milkManagement"
//            });
//            
//            if (tokenResponse.IsError)
//            {
//                Console.WriteLine(tokenResponse.Error);
//                return;
//            }
//
//            Console.WriteLine(tokenResponse.Json);
//            Console.WriteLine("\n\n");
//
//            // call api
//            //Api Server
//            var apiClient = new HttpClient();
//            apiClient.SetBearerToken(tokenResponse.AccessToken);
//
//            var response = await apiClient.GetAsync("http://localhost:5000/identity");
//            if (!response.IsSuccessStatusCode)
//            {
//                Console.WriteLine(response.StatusCode);
//            }
//            else
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                Console.WriteLine(JArray.Parse(content));
//            }
//            
//            
            
        }
    }
}