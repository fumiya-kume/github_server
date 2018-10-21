using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class KVSClient : IKVSClient
    {
        private IConfiguration configuration;

        public KVSClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private const string ParticionKey = "Folio";
        private string storageConnectionString() => configuration.GetValue<string>("storageConnectionString");
        private CloudStorageAccount storageClient() => CloudStorageAccount.Parse(storageConnectionString());

        public async Task SaveAsync(string tableName, string key, ITableEntity value)
        {
            CloudTableClient tableClient = storageClient().CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
            TableOperation insertOperation = TableOperation.InsertOrReplace(value);
            await table.ExecuteAsync(insertOperation);
        }

        public async Task<T> LoadWithKeyAsync<T>(string tableName, string key) where T : ITableEntity
        {
            CloudTableClient tableClient = storageClient().CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
            TableOperation loadOperation = TableOperation.Retrieve<T>(ParticionKey, key);
            TableResult loadResul = await table.ExecuteAsync(loadOperation);
            return ((T)loadResul.Result);
        }
    }
}
