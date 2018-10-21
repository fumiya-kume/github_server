using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class GithubClient : IGithubClient
    {
        private IConfiguration _configuration;

        public GithubClient(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<string> GetAccessTokenAsync(String code)
        {
            using (var client = new HttpClient())
            {
                var clientKey = _configuration.GetValue<String>("clientKey", "");
                var clientSercret = _configuration.GetValue<String>("clientSercret", "");
                var url = $"https://github.com/login/oauth/access_token?client_id={clientKey}&client_secret={clientSercret}&code={code}";
                var result = await client.GetAsync(url);
                return System.Web.HttpUtility.ParseQueryString(await result.Content.ReadAsStringAsync())["access_token"];
            }
        }
    }
}
