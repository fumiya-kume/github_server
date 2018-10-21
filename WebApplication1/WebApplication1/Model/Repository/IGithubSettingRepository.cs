using System.Threading.Tasks;

namespace WebApplication1.Model.Repository
{
    public interface IGithubSettingRepository
    {
        Task<string> LoadSetting(string key);
        Task WriteSetting(string key, string githubSetting);
    }
}