using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IQiitaSettingRepository qiitaSettingReposutory;
        private readonly IGithubSettingRepository githubSettingRepository;

        public ConfigController(
            IQiitaSettingRepository qiitaSettingRepository,
            IGithubSettingRepository githubSettingRepository
            )
        {
            qiitaSettingReposutory = qiitaSettingRepository;
            this.githubSettingRepository = githubSettingRepository;
        }
        
        [HttpGet("Qiita")]
        public async System.Threading.Tasks.Task<IActionResult> QiitaIdAsync([FromQuery]string code)
        {
            string qiitaSetting = await qiitaSettingReposutory.LoadSetting(code);
            return Ok(qiitaSetting);
        }

        [HttpPost("/Qiita")]
        public async System.Threading.Tasks.Task<IActionResult> QiitaIdAsync([FromQuery] string code, [FromQuery] string qiitaId)
        {
            await qiitaSettingReposutory.WriteSetting(code, qiitaId);
            return Ok();
        }

        [HttpGet("/Github")]
        public IActionResult GithubId([FromQuery] string code)
        {
            System.Threading.Tasks.Task<string> githubSetting = githubSettingRepository.LoadSetting(code);
            return Ok(githubSetting);
        }

        [HttpPost("/Github")]
        public async System.Threading.Tasks.Task<IActionResult> GithubIdAsync([FromQuery]string code, [FromQuery]string githubId)
        {
            await githubSettingRepository.WriteSetting(code, githubId);
            return Ok();
        }
    }
}