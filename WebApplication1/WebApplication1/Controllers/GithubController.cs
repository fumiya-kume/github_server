using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.Model;
using WebApplication1.Model.Repository;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private IConfiguration _configuration;
        private IGithubClient githubClient;
        
        public GithubController(IConfiguration configRation, IGithubClient githubClient)
        {
            _configuration = configRation;
            this.githubClient = githubClient;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var code = _configuration.GetValue<string>("clientKey", "");
            return Redirect($"https://github.com/login/oauth/authorize?client_id={code}");
        }

        [HttpGet("callback")]
        public async Task<IActionResult> CallBackAsync([FromQuery]String code)
        {
            var cookieOption = new CookieOptions();
            var accessToken = await githubClient.GetAccessTokenAsync(code);
            Response.Cookies.Append("accessToken", accessToken, cookieOption);
            // 管理画面へ遷移するようにする
            return Redirect("https://jphacks.azurewebsites.net/management/management.html");
        }
    }
}