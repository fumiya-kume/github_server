using System.Threading.Tasks;
using WebApplication1.Model.KVSEntity;

namespace WebApplication1.Model.Repository
{
    public class GithubSettingRepository : IGithubSettingRepository
    {
        private IKVSClient KVSClient { get; set; }
        private readonly string tableName = "githubsetting";

        public GithubSettingRepository(IKVSClient kVSClient)
        {
            KVSClient = kVSClient;
        }

        public async Task<string> LoadSetting(string key)
        {
            GithubTableEntity loadResult = await KVSClient.LoadWithKeyAsync<GithubTableEntity>(tableName, key);
            return loadResult.GithubId;
        }

        public async Task WriteSetting(string key, string githubSetting)
        {
            GithubTableEntity entity = new GithubTableEntity(githubSetting);
            await KVSClient.SaveAsync(tableName, key, entity);
        }
    }
}
