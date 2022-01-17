﻿using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class TwitterAuthorizationService : ITwitterAuthorizationService
    {

        public async Task<string> GetBearerToken(string apiKey, string secretKey)
        {
            var client = new RestClient("https://api.twitter.com/oauth2")
            {
                Authenticator = new HttpBasicAuthenticator(apiKey, secretKey)
            };

            // post to the "token" resource
            var request = new RestRequest("token");

            // add authorization parameters
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("grant_type", "client_credentials");

            var response = await client.PostAsync<AuthResult>(request);

            return response.access_token;
        }

    }
}
