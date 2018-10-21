using System.Threading.Tasks;

namespace WebApplication1.Model.Repository
{
    public interface IQiitaSettingRepository
    {
        Task<string> LoadSetting(string key);
        Task WriteSetting(string key, string QiitaSetting);
    }
}