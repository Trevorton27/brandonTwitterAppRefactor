﻿using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IContentSearchService
    {
        public Task<string> GetTweetsByContent(string searchTerm, string bearerToken);
    }
}